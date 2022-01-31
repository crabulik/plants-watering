namespace PlantsWatering.Server.Services.Repositories
{
    public interface IPlantsRepository
    {
        public Task<Plant[]> GetAllPlantsAsync();
    }
}
