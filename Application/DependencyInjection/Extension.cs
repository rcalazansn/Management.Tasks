using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;


namespace Application.DependencyInjection
{
    public static class Extension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ITaskApplication, TaskApplication>();
          
            return services;
        }
    }
}