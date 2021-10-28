using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RemoteWebApiClient.Services;
using Steeltoe.Discovery.Client;
using WebApiClient;
using WebApiClient.Extensions.DiscoveryClient;
using WebApiClient.Extensions.HttpClientFactory;

namespace RemoteWebApiClient
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Spring Cloud 相关配置
            // if (Configuration.GetValue<bool>("UseSpringCloud"))
            // {
            //     services.AddDiscoveryClient(Configuration.GetSection("SpringCloud"));
            // }

            services.AddApiClient<IUserApi>(options =>
            {
                options.HttpHost = new Uri("http://localhost:8000");
            });

            services.AddHttpContextAccessor();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Spring Cloud 相关配置
            // if (Configuration.GetValue<bool>("UseSpringCloud"))
            // {
            //     app.UseDiscoveryClient();
            // }
        }
    }
}
