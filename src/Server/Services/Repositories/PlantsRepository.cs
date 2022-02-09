using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PlantsWatering.Server.Db;
using PlantsWatering.Server.Db.Models;
using PlantsWatering.Server.Services.Mappers;
using PlantsWatering.Server.Settings;

namespace PlantsWatering.Server.Services.Repositories
{
    public class PlantsRepository: IPlantsRepository
    {
        public const string NotFoundValue = "Not Found";

        private readonly PlantsDbContext _plantsDbContext;
        private readonly IDboMapper _dboMapper;
        private readonly ChannelsSettings _settings;

        public PlantsRepository(PlantsDbContext plantsDbContext, IDboMapper dboMapper, IOptions<ChannelsSettings> settings)
        {
            _plantsDbContext = plantsDbContext ?? throw new ArgumentNullException(nameof(plantsDbContext));
            _dboMapper = dboMapper ?? throw new ArgumentNullException(nameof(dboMapper));
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }
            _settings = settings.Value;
        }

        public async Task<Plant[]> GetAllPlantsAsync()
        {
            var configuredChannels = _settings.DeviceChannels
                .Select(p => new CommunicationChannel(p.Id, p.Name))
                .ToArray();

            var allPlants = await _plantsDbContext
                .Plants
                .Where(w => !w.IsDeleted)
                .AsNoTracking()
                .ToArrayAsync();

            return allPlants
                .Select(p => _dboMapper.MapPlant(configuredChannels, p))
                .ToArray();
        }

        public async Task<(bool IsFound, Plant Result)> TryGetPlantByIdAsync(int plantId)
        {
            var configuredChannels = _settings.DeviceChannels
                .Select(p => new CommunicationChannel(p.Id, p.Name))
                .ToArray();

            var queryResult = await _plantsDbContext
                .Plants
                .Where(w => !w.IsDeleted)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == plantId);

            if (queryResult == null)
            {
                var result = new Plant(
                    int.MinValue,
                    NotFoundValue,
                    NotFoundValue,
                    new NotSetWateringSchedule(),
                    new CommunicationChannel(NotFoundValue, NotFoundValue));
                return (false, result);
            }
            else
            {
                var result = _dboMapper.MapPlant(configuredChannels, queryResult);
                return (true, result);
            }
        }

        public async Task<Plant> InsertPlantAsync(Plant plant)
        {
            var dbPlant = _dboMapper.MapPlant(plant);
            await _plantsDbContext.Plants.AddAsync(dbPlant);

            await _plantsDbContext.SaveChangesAsync();

            var configuredChannels = _settings.DeviceChannels
                .Select(p => new CommunicationChannel(p.Id, p.Name))
                .ToArray();
            return _dboMapper.MapPlant(configuredChannels, dbPlant);
        }

        public async Task<(bool IsFound, Plant UpdatedPlant)> TryUpdatePlantAsync(Plant plant)
        {
            void MutatePlant(PlantDbo origin, PlantDbo expectedState)
            {
                origin.Name = expectedState.Name;
                origin.Location = expectedState.Location;
                origin.WateringSchedule = expectedState.WateringSchedule;
                origin.CommunicationChannelId = expectedState.CommunicationChannelId;
                origin.IsDeleted = expectedState.IsDeleted;
            }

            var foundPlant = await _plantsDbContext
                .Plants
                .FirstOrDefaultAsync(p => p.Id == plant.Id);

            if (foundPlant == null)
            {
                return (false, plant);
            }

            var expectedState = _dboMapper.MapPlant(plant);

            MutatePlant(foundPlant, expectedState);

            await _plantsDbContext.SaveChangesAsync();
            var configuredChannels = _settings.DeviceChannels
                .Select(p => new CommunicationChannel(p.Id, p.Name))
                .ToArray();
            return (true, _dboMapper.MapPlant(configuredChannels, foundPlant));
        }

        public async Task<bool> TryDeletePlantByIdAsync(int plantId)
        {
            var foundPlant = await _plantsDbContext
                .Plants
                .FirstOrDefaultAsync(p => p.Id == plantId);

            if (foundPlant == null)
            {
                return false;
            }
            foundPlant.IsDeleted = true;

            await _plantsDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CheckPlantIsAvailiableByIdAsync(int plantId)
        {
            return await _plantsDbContext
                .Plants
                .AsNoTracking()
                .AnyAsync(p => p.Id == plantId);
        }
    }
}
