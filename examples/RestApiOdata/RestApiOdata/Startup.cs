using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.Extensions.Options;
using OData.Swagger.Services;
using Swashbuckle.AspNetCore.SwaggerGen;
using RestApiOdata.Models;

namespace RestApiOdata
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
            // ��� in-memory ���ݿ�
            var databaseName = Guid.NewGuid().ToString();
            services
                .AddEntityFrameworkInMemoryDatabase()
                .AddDbContext<AppDbContext>((sp, options) => options.UseInMemoryDatabase(databaseName).UseInternalServiceProvider(sp));

            // ��� OData��
            services.AddOData();

            // Swagger �������
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen();

            // �� ASP.NET Core 3.1 �� 5.0 ��ʹ�� Swagger ���� OData
            // https://github.com/KishorNaik/Sol_OData_Swagger_Support
            services.AddOdataSwaggerSupport();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Swagger �������
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "API Doc");

                options.RoutePrefix = "api-docs";
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                // �� OData 6.0.0 �����ϵİ汾��Ĭ���޷�ʹ����Щ���ܣ���Ҫ�ڴ˴�ָ������
                endpoints.Select().Expand().Filter().OrderBy().MaxTop(100).Count();
                // ���� OData ��·��ǰ׺���� http://*:5000/api/[controller] ���� OData ��������
                endpoints.MapODataRoute("api", "api", AppEdmModel.GetModel());
            });

            // �� UseEndpoints ������ OData������� UseOData ���� OData
            // app.UseOData("api", "api", AppEdmModel.GetModel());

            // ��ʼ��ʾ������
            using (var scpoe = app.ApplicationServices.CreateScope())
            {
                DataGenerator.InitSampleData(scpoe.ServiceProvider);
            }
        }
    }
}
