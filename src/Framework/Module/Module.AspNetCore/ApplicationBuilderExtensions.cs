namespace LiModular.Lib.Module.AspNetCore
{
    using LiModular.Lib.Module.Abstractions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseModules(this IApplicationBuilder app, IHostEnvironment env)
        {
            //解析服务,需要在服务里面进行注册,这里才能解析
            var modules = app.ApplicationServices.GetService<IModuleCollection>();
            foreach (var module in modules)
            {
                //加载模块初始化器
                ((ModuleDescriptor)module).Initializer?.Configure(app, env);
            }
            return app;
        }
    }
}
