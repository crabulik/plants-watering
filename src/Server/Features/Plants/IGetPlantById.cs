using PlantsWatering.Shared.Dtos.Plants;

namespace PlantsWatering.Server.Features.Plants
{
    public interface IGetPlantById
    {
        public Task<PlantDto> HandleAsync(int id);
    }
}
