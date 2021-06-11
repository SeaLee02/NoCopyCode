namespace LiModular.Module.Admin.Web
{
    using LiModular.Lib.Module.Abstractions;
    using LiModular.Lib.Module.AspNetCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System;

    public class ModuleInitializer : IModuleInitializer
    {
        /// <summary>
        /// 注册服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="modules"></param>
        /// <param name="env"></param>
        public void ConfigureServices(IServiceCollection services, IModuleCollection modules, IHostEnvironment env)
        {
            Console.WriteLine("模块里面的ConfigureServices");
        }
        
        /// <summary>
        /// 配置中间件
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            Console.WriteLine("模块里面的Configure");
        }

    }
}
