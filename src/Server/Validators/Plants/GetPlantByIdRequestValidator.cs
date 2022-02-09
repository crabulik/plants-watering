using FluentValidation;
using PlantsWatering.Server.Services.Repositories;
using PlantsWatering.Shared.Dtos.Plants;

namespace PlantsWatering.Server.Validators.Plants
{
    public class GetPlantByIdRequestValidator: AbstractValidator<GetPlantByIdRequestDto>
    {
        private readonly IPlantsRepository _plantsRepository;
        public GetPlantByIdRequestValidator(IPlantsRepository plantsRepository)
        {
            _plantsRepository = plantsRepository ?? throw new ArgumentNullException(nameof(plantsRepository));

            RuleFor(x => x.Id)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .GreaterThan(0)
                .MustAsync(PlantExist).WithErrorCode(ValidationErrorCodes.NotFoundEntity);
            
        }

        private async Task<bool> PlantExist(int id, CancellationToken tkn)
        {
            return await _plantsRepository.CheckPlantIsAvailiableByIdAsync(id);
        }
    }
}
