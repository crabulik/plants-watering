using AutoMapper;
using PlantsWatering.Shared.Dtos.Channels;
using PlantsWatering.Shared.Dtos.Plants;
using PlantsWatering.Shared.Dtos.WateringSchedules;

namespace PlantsWatering.Server.Mappings
{
    public class PlantsProfile : Profile
	{
		public PlantsProfile()
		{
            CreateMap<WateringSchedule, WateringScheduleDto>()
                .Include<NotSetWateringSchedule, WateringScheduleDto>()
                .Include<DailyWateringSchedule, WateringScheduleDto>()
                .Include<HourlyWateringSchedule, WateringScheduleDto>();
            CreateMap<NotSetWateringSchedule, WateringScheduleDto>()
                .AfterMap((s,d) =>
                {
                    d.WateringHour = null;
                    d.WateringMinute = null;
                    d.Rate = null;
                    d.Type = WateringScheduleType.NotSet;
                });
            CreateMap<DailyWateringSchedule, WateringScheduleDto>()
                .AfterMap((s, d) =>
                {
                    d.WateringHour = null;
                    d.WateringMinute = null;
                    d.Type = WateringScheduleType.Daily;
                });
            CreateMap<HourlyWateringSchedule, WateringScheduleDto>()
                .AfterMap((s, d) =>
                {
                    d.Rate = null;
                    d.Type = WateringScheduleType.Hourly;
                });

            CreateMap<CommunicationChannel, CommunicationChannelDto>();
            CreateMap<Plant, PlantDto>();
        }
	}
}
