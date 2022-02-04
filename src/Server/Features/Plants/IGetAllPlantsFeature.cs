using PlantsWatering.Shared.Dtos.Plants;

namespace PlantsWatering.Server.Features.Plants
{
    public interface IGetAllPlantsFeature
    {
        public Task<GetAllPlantsResponceDto> HandleAsync();
    }
}
