namespace LiModular.Lib.Module.AspNetCore
{
    using LiModular.Lib.Module.Abstractions;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// 
    /// </summary>
    public interface IModuleInitializer
    {
        /// <summary>
        /// 注入服务 
        /// <para>** 此方法用于注入与Web相关的服务，否则请通过IModuleServicesConfigurator接口注册</para>
        /// Microsoft.Extensions.Hosting.Abstractions  nuget包
        /// </summary>
        /// <param name="services"></param>
        /// <param name="modules">模块集合</param>
        /// <param name="env">环境变量</param>
        /// <param name="cfg">配置</param>
        void ConfigureServices(IServiceCollection services, IModuleCollection modules, IHostEnvironment env);

    }
}
