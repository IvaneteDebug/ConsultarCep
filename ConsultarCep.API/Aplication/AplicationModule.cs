using ConsultarCep.API.Https;
using ConsultarCep.API.Repositories;
using ConsultarCep.API.Services;

namespace ConsultarCep.API.Aplication
{
    public static class AplicationModule
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddServices();

            return services;
        }
        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddHttpClient<IViaCepIntegrationService, ViaCepIntegrationService>();

            services.AddScoped<ICepService, CepService>();
            services.AddScoped<IConsultarCepRepository, ConsultarCepRepository>();

            return services;
        }
    }
}
