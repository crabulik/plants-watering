using System.Reflection;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PlantsWatering.Server.Db;
using PlantsWatering.Server.Extensions;
using PlantsWatering.Server.Features.Channels;
using PlantsWatering.Server.Services.Repositories;
using PlantsWatering.Server.Settings;

public partial class Startup
{

    private void ConfigureWebServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddRazorPages();
        services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "My Plants Watering API", Version = "v1" });
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });
    }

    private void ConfigureSystemServices(IServiceCollection services)
    {
        services.AddDbContext<PlantsDbContext>(options =>
            options.UseSqlite(Configuration.GetConnectionString(nameof(PlantsDbContext))));
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddAutoMapper(typeof(Startup));
    }

    private void ConfigureApplicationServices(IServiceCollection services)
    {
        services.AddScoped<IChannelsRepository, ChannelsRepository>();
        
        
        services.AddScoped<IGetAvailableCommunicationChannelsFeature,
            GetAvailableCommunicationChannelsFeature>();
    }

    private void ConfigureSettings(IServiceCollection services)
    {
        services.ConfigureSettings<ChannelsSettings>(Configuration);
    }
}