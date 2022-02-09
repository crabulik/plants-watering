namespace PlantsWatering.Server.Services.Repositories
{
    public interface IPlantsRepository
    {
        public Task<Plant[]> GetAllPlantsAsync();

        public Task<(bool IsFound, Plant Result)> TryGetPlantByIdAsync(int plantId);

        public Task<Plant> InsertPlantAsync(Plant plant);

        public Task<(bool IsFound, Plant UpdatedPlant)> TryUpdatePlantAsync(Plant plant);

        // The result value represent if there is an entity with the Id == plantId.
        // For the idempotency, the method returns true even if the entity has been already deleted.
        public Task<bool> TryDeletePlantByIdAsync(int plantId);

        public Task<bool> CheckPlantIsAvailiableByIdAsync(int plantId);
    }
}
