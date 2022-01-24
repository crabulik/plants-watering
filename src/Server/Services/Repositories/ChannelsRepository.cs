using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PlantsWatering.Server.Db;
using PlantsWatering.Server.Settings;

namespace PlantsWatering.Server.Services.Repositories
{
    public class ChannelsRepository: IChannelsRepository
    {
        private readonly PlantsDbContext _plantsDbContext;
        private readonly ChannelsSettings _settings;

        public ChannelsRepository(PlantsDbContext plantsDbContext, IOptions<ChannelsSettings> settings)
        {
            _plantsDbContext = plantsDbContext ?? throw new ArgumentNullException(nameof(plantsDbContext));
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }
            _settings = settings.Value;
        }

        public async Task<CommunicationChannel[]> GetUnusedChannels()
        {
            var usedChannelsIds = await _plantsDbContext.Plants
                .Select(p => p.CommunicationChannelId)
                .AsNoTracking()
                .ToArrayAsync();

            return _settings.DeviceChannels
                .Where(w => !usedChannelsIds.Contains(w.Name))
                .Select(p => new CommunicationChannel(p.Id, p.Name))
                .ToArray();
        }
    }
}