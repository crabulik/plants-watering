using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PlantsWatering.Server.Db;
using PlantsWatering.Server.Services.Mappers;
using PlantsWatering.Server.Settings;

namespace PlantsWatering.Server.Services.Repositories
{
    public class PlantsRepository: IPlantsRepository
    {
        private readonly PlantsDbContext _plantsDbContext;
        private readonly IDboMapper dboMapper;
        private readonly ChannelsSettings _settings;

        public PlantsRepository(PlantsDbContext plantsDbContext, IDboMapper dboMapper, IOptions<ChannelsSettings> settings)
        {
            _plantsDbContext = plantsDbContext;
            this.dboMapper = dboMapper;
            _settings = settings.Value;
        }

        public async Task<Plant[]> GetAllPlantsAsync()
        {
            var configuredChannels = _settings.DeviceChannels
                .Select(p => new CommunicationChannel(p.Id, p.Name))
                .ToArray();

            var allPlants = await _plantsDbContext
                .Plants
                .Select(p => p)
                .AsNoTracking()
                .ToArrayAsync();

            return allPlants
                .Select(p => dboMapper.MapPlant(configuredChannels, p))
                .ToArray();
        }

        
    }
}
