using Microsoft.EntityFrameworkCore;
using PlantsWatering.Server.Db.Models;

namespace PlantsWatering.Server.Db
{
    public class PlantsDbContext: DbContext
    {
        public PlantsDbContext(DbContextOptions<PlantsDbContext> options)
            : base(options)
        {
        }

        public DbSet<PlantDbo> Plants => Set<PlantDbo>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<PlantDbo>()
                .ToTable("Plants")
                .OwnsOne(
                    p => p.WateringSchedule,
                    od =>
                    {
                        od.Property(p => p.Type)
                            .HasConversion<string>();
                    });
        }
    }
}
