namespace PlantsWatering.Server.Extensions
{
    public static class OptionsExtensions
    {
        public static IServiceCollection ConfigureSettings<TOptions>(this IServiceCollection services, IConfiguration configuration) where TOptions : class
        {
            return services.Configure<TOptions>(configuration.GetSection(nameof(TOptions)));
        }
    }
}
