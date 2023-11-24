using Hakaton.Application.Domain.Subjects.Services;
using Hakaton.Application.Domain.Users;
using Hakaton.Infrastruct.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hakaton.Infrastruct;

public static class Bootstraps
{
    public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<ISubjectService, SubjectsService>();
        services.AddDbContext<DataContext>(options =>
                                               options.UseNpgsql(
                                                   configuration.GetConnectionString("Database")));

        return services;
    }
}