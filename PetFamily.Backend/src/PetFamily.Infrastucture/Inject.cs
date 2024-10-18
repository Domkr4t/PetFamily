using Microsoft.Extensions.DependencyInjection;
using PetFamily.Application.Volunteers;
using PetFamily.Infrastucture.Repositories;

namespace PetFamily.Infrastucture
{
    public static class Inject
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbConbext>();

            services.AddScoped<IVolunteersRepository, VolunteersRepository>();

            return services;
        }
    }
}
