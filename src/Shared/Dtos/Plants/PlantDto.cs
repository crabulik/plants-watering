using PlantsWatering.Shared.Dtos.Channels;
using PlantsWatering.Shared.Dtos.WateringSchedules;

namespace PlantsWatering.Shared.Dtos.Plants
{
    public class PlantDto
    {
        public int Id { get; set; } = 0;

        public string Name { get; set; } = String.Empty;

        public string Location { get; set; } = String.Empty;

        public WateringScheduleDto WateringSchedule { get; set; } = new WateringScheduleDto();

        public CommunicationChannelDto CommunicationChannel { get; set; } = new CommunicationChannelDto();
    }
}
