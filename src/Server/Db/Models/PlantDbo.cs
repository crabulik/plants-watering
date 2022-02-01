using System.ComponentModel.DataAnnotations;

namespace PlantsWatering.Server.Db.Models
{
    public class PlantDbo
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(250)]
        public string Location { get; set; } = string.Empty;

        [MaxLength(20)]
        public string CommunicationChannelId { get; set; } = string.Empty;

        public WateringScheduleDbo WateringSchedule { get; set; } = new();

        public bool IsDeleted { get; set; } = false;
    }
}
