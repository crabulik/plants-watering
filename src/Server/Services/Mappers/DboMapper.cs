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
    }
}
