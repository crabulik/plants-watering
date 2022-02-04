using AutoMapper;
using PlantsWatering.Server.Services.Repositories;
using PlantsWatering.Shared.Dtos.Plants;

namespace PlantsWatering.Server.Features.Plants
{
    public class GetAllPlantsFeature: IGetAllPlantsFeature
    {
        private readonly IPlantsRepository _plantsRepository;
        private readonly IMapper _mapper;

        public GetAllPlantsFeature(IPlantsRepository plantsRepository, IMapper mapper)
        {
            _plantsRepository = plantsRepository ?? throw new ArgumentNullException(nameof(plantsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<GetAllPlantsResponceDto> HandleAsync()
        {
            var plants = await _plantsRepository.GetAllPlantsAsync();

            return new GetAllPlantsResponceDto
            {
                Plants = _mapper.Map<PlantDto[]>(plants)
            };
        }
    }
}
