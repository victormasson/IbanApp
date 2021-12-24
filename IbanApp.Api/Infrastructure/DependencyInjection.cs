using System.Reflection;
using IbanApp.Domain.Interfaces;
using IbanApp.Domain.Services;
using IbanApp.Domain.Services.Interfaces;
using IbanApp.Domain.UseCases.InformationBancaires.Commands;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace IbanApp.Api.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(IApplicationDbContext));
            services.AddScoped<IInformationBancaireService, InformationBancaireService>();

            return services;
        }
    }
}