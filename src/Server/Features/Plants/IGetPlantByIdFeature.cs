using FluentValidation.Results;
using PlantsWatering.Shared.Dtos.Plants;

namespace PlantsWatering.Server.Features.Plants
{
    public interface IGetPlantByIdFeature
    {
        public Task<ValidationResult> ValidateAsync(GetPlantByIdRequestDto request);
        public Task<PlantDto> HandleAsync(GetPlantByIdRequestDto request);
    }
}
