using SchoolSchedule.Application.Contracts;
using SchoolSchedule.Infrastructure.Data;
using SchoolSchedule.Infrastructure.Repository;

namespace SchoolSchedule.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<ICommandStudentRepository, CommandStudentRepository>();
        services.AddTransient<IQueryStudentRepository, QueryStudentRepository>();

        services.AddScoped(x => new CommandStudentRepository(x.GetService<ApplicationDbContext>()));
        services.AddScoped(x => new QueryStudentRepository(x.GetService<ApplicationDbContext>()));

        return services;
    }
}
