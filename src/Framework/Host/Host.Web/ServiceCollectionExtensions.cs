namespace LiModular.Lib.Host.Web
{
    using LiModular.Lib.Mapper.AutoMapper;
    using LiModular.Lib.Module.AspNetCore;
    using LiModular.Lib.Swagger.Core;
    using LiModular.Lib.Utils.Core.Configuration;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;


    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加WebHost
        /// </summary>
        /// <param name="services"></param>
        /// <param name="hostOptions"></param>
        /// <param name="env">环境</param>
        /// <param name="cfg"></param>
        /// <returns></returns>
        public static IServiceCollection AddWebHost(this IServiceCollection services, IHostEnvironment env, IConfiguration cfg)
        {
            //管理全局配置文件
            services.AddSingleton(new Appsettings(cfg));

            //初始化模块数据
            var module = services.AddModules();
            //添加模块ConfigureServices 
            services.AddModuleInitializerServices(module, env);

            //AutoMapper配置
            services.AddMappers(module);

            //添加Swagger
            services.AddSwagger(module);


            //添加控制器                      
            services.AddControllers(o =>
            {

            });
            return services;
        }


    }
}
