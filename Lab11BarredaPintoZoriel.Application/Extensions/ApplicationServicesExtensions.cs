using System.Reflection;
using Lab10BarredaPintoZoriel.Application.Commands.CreateResponse;
using Lab10BarredaPintoZoriel.Application.Commands.CreateRole;
using Lab10BarredaPintoZoriel.Application.Commands.CreateTicket;
using Lab10BarredaPintoZoriel.Application.Queries.GetAllResponse;
using Lab10BarredaPintoZoriel.Application.Queries.GetAllUser;
using Lab10BarredaPintoZoriel.Application.Queries.GetAllUserRole;
using Lab11BarredaPintoZoriel.Application.Commands.CreateUser;
using Lab11BarredaPintoZoriel.Application.Commands.CreateUserRole;
using Lab11BarredaPintoZoriel.Application.Queries.GetAllRoles;
using Lab11BarredaPintoZoriel.Application.Queries.GetAllTickets;
using Lab11BarredaPintoZoriel.Domain.Interfaces;
using Lab11BarredaPintoZoriel.Infrastructure.Models;
using Lab11BarredaPintoZoriel.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lab11BarredaPintoZoriel.Extensions
{
    public static class ProjectServicesExtensions
    {           
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                cfg.RegisterServicesFromAssembly(typeof(CreateUserHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetAllUsersHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(CreateRoleHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetAllRolesHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(CreateUserRoleHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetAllUserRolesHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(CreateTicketHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetAllTicketsHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(CreateResponseHandler).Assembly);
                cfg.RegisterServicesFromAssembly(typeof(GetAllResponsesHandler).Assembly);
            });
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}