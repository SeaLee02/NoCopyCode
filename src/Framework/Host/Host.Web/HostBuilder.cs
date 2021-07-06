namespace LiModular.Lib.Host.Web
{
    using LiModular.Lib.Logging.Serilog;
    using LiModular.Lib.Utils.Core.Configuration;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Hosting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using HostOptions = LiModular.Lib.Host.Web.Options.HostOptions;

    public class HostBuilder
    {
        /// <summary>
        /// 启动
        /// </summary>
        /// <typeparam name="TStartup"></typeparam>
        /// <param name="args">启动参数</param>
        public void Run<TStartup>(string[] args) where TStartup : StartupAbstract
        {
            CreateBuilder<TStartup>(args).Build().Run();
        }

        /// <summary>
        /// 创建主机生成器
        /// </summary>
        /// <typeparam name="TStartup"></typeparam>
        /// <param name="args"></param>
        /// <returns></returns>
        public IHostBuilder CreateBuilder<TStartup>(string[] args) where TStartup : StartupAbstract
        {
            Console.WriteLine("CreateBuilder:Start");

            var config = ConfigurationHelper.GetConfig();
            var hostOptions = new HostOptions();
            config.GetSection("Host").Bind(hostOptions);

            if (hostOptions.Urls.IsNull())
                hostOptions.Urls = "http://*:5000";

            return Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
                    .UseDefaultServiceProvider(options => { options.ValidateOnBuild = false; })
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseLogging()
                        .UseStartup<TStartup>()
                        .UseUrls(hostOptions.Urls);
                    });
        }
    }
}
