using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkUp.Tests.Config
{
    public class ParkUpAppFactory<T> : WebApplicationFactory<T> where T : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseStartup<T>();
        }
    }
}
