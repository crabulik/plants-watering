using PlantsWatering.Server.Db.Models;

namespace PlantsWatering.Server.Services.Mappers
{
    public class DboMapper : IDboMapper
    {
        public Plant MapPlant(CommunicationChannel[] configuredChannels, PlantDbo plant)
        {
            HourlyWateringSchedule MapHourlySchedule(WateringScheduleDbo schedule)
            {
                if (schedule.Rate == null)
                {
                    throw new DomainInitialisationException(
                        $"Hourly type of WateringSchedule registered in DB has a null value of Rate property.");
                }

                return new HourlyWateringSchedule(schedule.Rate.Value);
            }

            DailyWateringSchedule MapDailySchedule(WateringScheduleDbo schedule)
            {
                if (schedule.WateringHour == null)
                {
                    throw new DomainInitialisationException(
                        $"Daily type of WateringSchedule registered in DB has a null value of WateringHour property.");
                }
                if (schedule.WateringMinute == null)
                {
                    throw new DomainInitialisationException(
                        $"Daily type of WateringSchedule registered in DB has a null value of WateringMinute property.");
                }

                return new DailyWateringSchedule(
                    schedule.WateringHour.Value,
                    schedule.WateringMinute.Value);
            }

            WateringSchedule wateringSchedule = plant.WateringSchedule.Type switch
            {
                WateringScheduleTypeDbo.NotSet => new NotSetWateringSchedule(),
                WateringScheduleTypeDbo.Hourly => MapHourlySchedule(plant.WateringSchedule),
                WateringScheduleTypeDbo.Daily => MapDailySchedule(plant.WateringSchedule),
                _ => throw new DomainInitialisationException(
                    $"Unknown WateringScheduleType registered in DB: {plant.WateringSchedule.Type}.")
            };



            var communicationChannel = configuredChannels
                .FirstOrDefault(p => string.Equals(p.Id, plant.CommunicationChannelId))
                ?? throw new DomainInitialisationException(
                    $"Unknown CommunicationChannelId ({plant.CommunicationChannelId}) for the plant: {plant.Id}:{plant.Name}.");

            return new Plant(
                    plant.Id,
                    plant.Name,
                    plant.Location,
                    wateringSchedule,
                    communicationChannel
                );
        }

        public PlantDbo MapPlant(Plant plant)
        {
            var schedule = plant.WateringSchedule switch
            {
                NotSetWateringSchedule p => new WateringScheduleDbo
                {
                    Type = WateringScheduleTypeDbo.NotSet,
                    Rate = null,
                    WateringHour = null,
                    WateringMinute = null
                },
                HourlyWateringSchedule p => new WateringScheduleDbo
                {
                    Type = WateringScheduleTypeDbo.Hourly,
                    Rate = p.Rate,
                    WateringHour = null,
                    WateringMinute = null
                },
                DailyWateringSchedule p => new WateringScheduleDbo
                {
                    Type = WateringScheduleTypeDbo.Daily,
                    Rate = null,
                    WateringHour = p.WateringHour,
                    WateringMinute = p.WateringMinute
                },
                _ => throw new DomainInitialisationException($"The WateringSchedule type {plant.WateringSchedule.GetType().Name} has no implemented mapping in {nameof(DboMapper)}")
            };

            return new PlantDbo
            {
                Id = plant.Id,
                Name = plant.Name,
                Location = plant.Location,
                CommunicationChannelId = plant.CommunicationChannel.Id,
                WateringSchedule = schedule
            };
        }
    }
}
