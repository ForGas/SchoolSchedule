using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolSchedule.Application.Contracts;
using SchoolSchedule.Infrastructure.Data;
using SchoolSchedule.Infrastructure.Repository;

namespace SchoolSchedule.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                .UseLazyLoadingProxies());

        services.AddTransient<IApplicationDbContext, ApplicationDbContext>();

        return services;
    }

    public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<ICommandStudentRepository, CommandStudentRepository>();
        services.AddTransient<IQueryStudentRepository, QueryStudentRepository>();

        services.AddScoped(x => new CommandStudentRepository(context: x.GetRequiredService<ApplicationDbContext>()));
        services.AddScoped(x => new QueryStudentRepository(context: x.GetRequiredService<ApplicationDbContext>()));

        return services;
    }
}
