namespace PlantsWatering.Server.Db.Models
{
    public enum WateringScheduleTypeDbo
    {
        NotSet = 0,
        Daily = 1,
        Hourly = 2
    }

    public class WateringScheduleDbo
    {
        public WateringScheduleTypeDbo Type { get; set; } = WateringScheduleTypeDbo.NotSet;

        public int? WateringHour { get; set; }

        public int? WateringMinute { get; set; }

        public int? Rate { get; set; }
    }
}
