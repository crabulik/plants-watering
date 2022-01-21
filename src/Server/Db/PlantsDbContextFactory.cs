using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PlantsWatering.Server.Db
{
    public class PlantsDbContextFactory : IDesignTimeDbContextFactory<PlantsDbContext>
    {
        public PlantsDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PlantsDbContext>();
            optionsBuilder.UseSqlite("Data Source=${PW_DATA}/plants-watering.db");

            return new PlantsDbContext(optionsBuilder.Options);
        }
    }
}