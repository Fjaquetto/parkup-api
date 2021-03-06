using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParkUp.CC.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkUp.Services.Api.Configuration
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootstrapper.RegisterServices(services, configuration);
        }
    }
}
