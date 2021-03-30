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
            services.AddScoped<IPatioAppService, PatioAppService>();

            //Infra - Data
            services.AddScoped<IContextDapper, ContextDapper>();
            services.AddScoped<IEmpresasRepository, EmpresasRepository>();
            services.AddScoped<IPatioRepository, PatioRepository>();

            //Infra - Query
            services.AddScoped<IEmpresasQuery, EmpresasQuery>();
            services.AddScoped<IPatioQuery, PatioQuery>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}
