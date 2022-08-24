using KeysetPagination.Domain.Interfaces.Repository;
using KeysetPagination.Infrastructure.Database;
using KeysetPagination.Infrastructure.Database.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KeysetPagination.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("Default");

        // Register EF Core DB context
        services.AddDbContext<SchoolDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<IStudentRepository, StudentRepository>();

        return services;
    }
}
