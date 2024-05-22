using Domain.Interfaces.Repositories;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;

namespace Infrastructure.DependencyInjection
{
    public static class Extension
    {
        public static IServiceCollection AddManagementTaskDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbManagementTasks");

            services.AddScoped<IDbConnection>(_ => new SqlConnection(connectionString));

            services.AddDbContext<ManagementTaskDbContext>(x => x.
            UseSqlServer(connectionString,
            options => options.EnableRetryOnFailure(
                maxRetryCount: 10,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null
                )
            ), ServiceLifetime.Transient);
            return services;
        }
 

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITaskRepository, TaskRepository>();
       
            return services;
        }    
    }
}
