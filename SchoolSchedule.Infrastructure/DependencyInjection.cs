using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolSchedule.Infrastructure.Data;
using SchoolSchedule.Infrastructure.Repository;
using SchoolSchedule.Infrastructure.Repository.Shared.Student.Abstractions;

namespace SchoolSchedule.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            //.AddEntityFrameworkSqlServer()
            .AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                    .UseLazyLoadingProxies();
            }, ServiceLifetime.Scoped);

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

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
