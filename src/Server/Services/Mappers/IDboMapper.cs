using PlantsWatering.Server.Db.Models;

namespace PlantsWatering.Server.Services.Mappers
{
    public interface IDboMapper
    {
        public Plant MapPlant(CommunicationChannel[] configuredChannels, PlantDbo plant);
    }
}
