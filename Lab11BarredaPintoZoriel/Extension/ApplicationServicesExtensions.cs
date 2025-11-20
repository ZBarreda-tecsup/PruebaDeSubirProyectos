
using MediatR;
using Microsoft.OpenApi.Models;

namespace Lab11BarredaPintoZoriel;

public static class ApplicationServicesExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // ✅ Agregar Swagger
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Lab11 API",
                Version = "v1",
                Description = "API del laboratorio 11 con patrón CQRS + MediatR"
            });
        });

        // ✅ Registrar MediatR (si lo usas)
        services.AddMediatR(typeof(ApplicationServicesExtensions).Assembly);


        return services;
    }
}