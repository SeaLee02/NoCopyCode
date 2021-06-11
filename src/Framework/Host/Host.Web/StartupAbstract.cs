namespace LiModular.Lib.Host.Web
{
    using LiModular.Lib.Module.AspNetCore;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using HostOptions = LiModular.Lib.Host.Web.Options.HostOptions;


    /// <summary>
    /// 启动配置类基类
    /// </summary>
    public abstract class StartupAbstract
    {
        protected readonly IHostEnvironment _env;
        private readonly IConfiguration _cfg;


        protected StartupAbstract(IHostEnvironment env, IConfiguration cfg)
        {
            _env = env;
            _cfg = cfg;
        }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddWebHost(_env, _cfg);
        }

        public virtual void Configure(IApplicationBuilder app, IHostApplicationLifetime appLifetime)
        {
            app.UseWebHost(_env);

            //app.UseShutdownHandler();

            //appLifetime.ApplicationStarted.Register(() =>
            //{
            //    //显示启动Logo
            //    app.ApplicationServices.GetService<IStartLogoProvider>().Show(_hostOptions);
            //});
        }
    }
}
