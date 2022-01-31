namespace PlantsWatering.Shared.Dtos.WateringSchedules
{
    public enum WateringScheduleType
    {
        NotSet = 0,
        Daily = 1,
        Hourly = 2
    }

    public class WateringScheduleDto
    {
        public WateringScheduleType Type { get; set; } = WateringScheduleType.NotSet;

        public string Name { get; set; } = string.Empty;

        public int? WateringHour { get; set; }

        public int? WateringMinute { get; set; }

        public int? Rate { get; set; }
    }
}
