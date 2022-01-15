using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnalyticsDashboard.Api.Service;
using AnalyticsDashboard.Api.Service.Interface;
using AnalyticsDashboard.Data;
using AnalyticsDashboard.Data.Repository.Interface;
using AnalyticsDashboard.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using AnalyticsDashboard.Api.Mappings.Configuration;
using AnalyticsDashboard.Api.Middleware;

namespace AnalyticsDashboard.Api
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

            services.AddDbContext<AnalyticsDashboardDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddControllers();

            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder => builder
            //        .WithOrigins("https://localhost:3000", "http://localhost:5000", "https://localhost:5001", "http://localhost:3000", "https://localhost:4200", "http://localhost:4200")
            //        .AllowAnyMethod()
            //        .AllowAnyHeader()
            //        .AllowCredentials()
            //         );
            //});

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Analytics Dashboard Api", Version = "v1" });
            });

            services.AddLogging();
            services.AddAutoMapperSetup();

            services.AddTransient(sp => sp);
            services.AddScoped<ICommodityService, CommodityService>();
            services.AddScoped<ICommodityRepository, CommodityRepository>();

            services.AddScoped<ITradeService, TradeService>();
            services.AddScoped<ITradeRepository, TradeRepository>();

            services.AddScoped<ITradingModelService, TradingModelService>();
            services.AddScoped<ITradingModelRepository, TradingModelRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();

            // app.UseCors("CorsPolicy");

            app.UseCors(configurePolicy => configurePolicy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseExceptionMiddlewareExtensions();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
