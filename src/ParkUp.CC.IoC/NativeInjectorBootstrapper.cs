using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using ParkUp.CC.Identity.Authorization;
using ParkUp.CC.Identity.Models;
using ParkUp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkUp.CC.IoC
{
    public class NativeInjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}
