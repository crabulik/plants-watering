using Microsoft.EntityFrameworkCore;
using PlantsWatering.Server.Db;

public partial class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        ConfigureSystemServices(services);
        ConfigureWebServices(services);
        ConfigureSettings(services);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // Configure the HTTP request pipeline.
        app.UseForwardedHeaders();
        // Patch path base with forwarded path
        app.UseForwardPath();

        if (env.IsDevelopment())
        {
            app.UseWebAssemblyDebugging();
            app.UseDeveloperExceptionPage();
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        InitialiseDb(app);

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            // UI is accessible on the {HOST}/swagger/ route.
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Plants Watering API V1");
        });

        app.UseHttpsRedirection();

        app.UseBlazorFrameworkFiles();
        app.UseStaticFiles();

        app.UseRouting();
        

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapRazorPages();
            endpoints.MapControllers();
            endpoints.MapFallbackToFile("index.html");
        });
           
    }

    private void InitialiseDb(IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var services = scope.ServiceProvider;

            var context = services.GetRequiredService<PlantsDbContext>();
            context.Database.Migrate();
        }
    }
}