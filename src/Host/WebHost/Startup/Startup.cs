using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiModular.Lib.Module.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LiModular.WebHost
{
    public class Startup
    {
        protected readonly IHostEnvironment _env;


        public IConfiguration _configuration { get; }
        public Startup(IHostEnvironment env, IConfiguration configuration)
        {
            this._env = env;
            this._configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            //初始化模块数据
            var module = services.AddModules();
            //添加模块ConfigureServices 
            services.AddModuleInitializerServices(module, _env);



        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
