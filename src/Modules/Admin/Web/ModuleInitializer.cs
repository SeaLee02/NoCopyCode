namespace LiModular.Module.Admin.Web
{
    using LiModular.Lib.Module.Abstractions;
    using LiModular.Lib.Module.AspNetCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System;

    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigureServices(IServiceCollection services, IModuleCollection modules, IHostEnvironment env)
        {
            Console.WriteLine("模块里面的ConfigureServices");
        }
    }
}
