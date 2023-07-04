

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TerraInvestimentos.Application.Common.Interfaces;
using TerraInvestimentos.Infrastructure.Identity;
using TerraInvestimentos.Infrastructure.Persistence;
using TerraInvestimentos.Infrastructure.Persistence.Interceptors;
using TerraInvestimentos.Infrastructure.Services;

namespace TerraInvestimentos.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("TerraInvestimentosDb"));
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ApplicationDbContextInitialiser>();

        services
            .AddDefaultIdentity<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddHttpClient("github-api", c =>
        {
            c.BaseAddress = new Uri(configuration.GetSection("GitHubApi:Url").Value);

            //c.DefaultRequestHeaders.Add(configuration.GetSection("GitHubApi:Key:Key").Value, configuration.GetSection("OpenWeatherApi:Key:Value").Value);

            //c.DefaultRequestHeaders.Add(configuration.GetSection("OpenWeatherApi:Host:Key").Value, configuration.GetSection("OpenWeatherApi:Host:Value").Value);
        });

        services.AddTransient<IHttpClientHandler, Services.Handlers.HttpClientHandler>();
        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IIdentityService, IdentityService>();
        services.AddTransient<IGithubService, GithubService>();

        services.AddAuthorization(options =>
            options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator")));

        return services;
    }
}
