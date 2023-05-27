using SBcredito.Data.Repositories;
using SBcredito.Domain.Contracts.Repositories;
using SBcredito.Domain.Contracts.Services;
using SBcredito.Domain.Services;

namespace SBcredito.API.Configuration
{

    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<ITituloAnaliseService, TituloAnaliseService>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
