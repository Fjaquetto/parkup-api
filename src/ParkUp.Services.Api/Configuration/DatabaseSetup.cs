using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ParkUp.CC.Identity.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ParkUp.Services.Api.Configuration
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            string dbConnectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(dbConnectionString)));

            // Inject IDbConnection, with implementation from SqlConnection class.
            services.AddTransient<IDbConnection>((sp) => new SqlConnection(dbConnectionString));
        }
    }
}
