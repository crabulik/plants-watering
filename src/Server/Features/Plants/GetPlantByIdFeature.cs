using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using PlantsWatering.Server.Exceptions.Domain;
using PlantsWatering.Server.Services.Repositories;
using PlantsWatering.Shared.Dtos.Plants;

namespace PlantsWatering.Server.Features.Plants
{
    public class GetPlantByIdFeature : IGetPlantByIdFeature
    {
        private readonly IValidator<GetPlantByIdRequestDto> _validator;
        private readonly IPlantsRepository _plantsRepository;
        private readonly IMapper _mapper;

        public GetPlantByIdFeature(IValidator<GetPlantByIdRequestDto> validator, IPlantsRepository plantsRepository, IMapper mapper)
        {
            _validator = validator ?? throw new ArgumentNullException(nameof(validator));
            _plantsRepository = plantsRepository ?? throw new ArgumentNullException(nameof(plantsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ValidationResult> ValidateAsync(GetPlantByIdRequestDto request)
        {
            return await _validator.ValidateAsync(request);
        }

        public async Task<PlantDto> HandleAsync(GetPlantByIdRequestDto request)
        {
            var result = await _plantsRepository.TryGetPlantByIdAsync(request.Id);

            if(!result.IsFound)
            {
                throw new UnvalidModelException($"The plant with the id: {request.Id} is not found.");
            }

            return _mapper.Map<PlantDto>(result.Result);
        }
    }
}
