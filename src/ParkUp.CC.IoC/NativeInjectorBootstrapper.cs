using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParkUp.Application.Interfaces;
using ParkUp.Application.Services;
using ParkUp.CC.Identity.Authorization;
using ParkUp.CC.Identity.Models;
using ParkUp.Domain.Interfaces;
using ParkUp.Infra.Data.Context.ContextDapper;
using ParkUp.Infra.Data.Repository;
using ParkUp.Infra.Data.Repository.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkUp.CC.IoC
{
    public class NativeInjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();
            services.AddSingleton<IConfiguration>(configuration);

            //Application
            services.AddScoped<IEmpresasAppService, EmpresasAppService>();

            //Infra - Data
            services.AddScoped<IContextDapper, ContextDapper>();
            services.AddScoped<ITipoPrecoRepository, EmpresasRepository>();

            //Infra - Query
            services.AddScoped<IEmpresasQuery, EmpresasQuery>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}
