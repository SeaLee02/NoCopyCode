namespace LiModular.Lib.Module.AspNetCore
{
    using LiModular.Lib.Module.Abstractions;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System.Collections.Generic;

    public static class ServiceCollectionExtensions
    {
        public static IModuleCollection AddModulesCore(this IServiceCollection services, IHostEnvironment environment, IConfiguration configuration)
        {
            //var moduleOptionsList = configuration.Get<List<ModuleOptions>>("Mkh:Modules");

            //var modules = new ModuleCollection(environment);
            //modules.Load(moduleOptionsList);

            //services.AddSingleton<IModuleCollection>(modules);
            var modules = new ModuleCollection();
            return modules;
        }



        /// <summary>
        /// 添加模块
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IModuleCollection AddModules(this IServiceCollection services)
        {
            var modules = new ModuleCollection();
            //加载所有的模块
            modules.Load();
            //注入
            services.AddSingleton<IModuleCollection>(modules);
            foreach (var module in modules)
            {
                if (module == null)
                    continue;

                services.AddSingleton(module);
            }

            return modules;
        }



        /// <summary>
        /// 添加模块初始化服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="modules"></param>
        /// <param name="env"></param>
        /// <param name="cfg"></param>
        /// <returns></returns>
        public static IServiceCollection AddModuleInitializerServices(this IServiceCollection services, IModuleCollection modules, IHostEnvironment env)
        {
            foreach (var module in modules)
            {
                //加载模块初始化器
                ((ModuleDescriptor)module).Initializer?.ConfigureServices(services, modules, env);
            }

            return services;
        }


    }
}
