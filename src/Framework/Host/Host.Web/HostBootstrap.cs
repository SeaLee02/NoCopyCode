using LiModular.Lib.Utils.Core.Options;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiModular.Lib.AOP.AspNetCore;

namespace LiModular.Lib.Host.Web
{
    public class HostBootstrap
    {
        private readonly string[] _args;

        public HostBootstrap(string[] args)
        {
            _args = args;
        }

        /// <summary>
        /// 创建IHost
        /// </summary>
        /// <returns></returns>
        public void Run<TStartup>() where TStartup : StartupAbstract
        {
            Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(_args)             
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    var options = LoadOptions();

                    //使用Serilog日志
                    webBuilder.UseSerilog((hostingContext, loggerConfiguration) =>
                    {
                        loggerConfiguration
                            .ReadFrom
                            .Configuration(hostingContext.Configuration)
                            .Enrich
                            .FromLogContext();
                        //if (!environmentVariable.Equals("Development"))
                        //{
                        //    _loggerConfiguration.WriteTo.MSSqlServer(
                        //    connectionString: dbCon,
                        //     sinkOptions: new MSSqlServerSinkOptions { TableName = "Sys_Log", AutoCreateSqlTable = true },
                        //     restrictedToMinimumLevel: LogEventLevel.Error
                        //    );
                        //}
                    });

                    //将宿主配置项注入容器
                    webBuilder.ConfigureServices(services =>
                    {
                        services.AddSingleton(options);
                    });

                    //绑定启动类
                    webBuilder.UseStartup<TStartup>();

                    //绑定URL
                    webBuilder.UseUrls(HostModel.Urls);

                }).AddAspCoreIoc()
                .Build()
                .Run();
        }

        /// <summary>
        /// 加载宿主配置项
        /// </summary>
        /// <returns></returns>
        private HostModel LoadOptions()
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", false);

            var environmentVariable = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (environmentVariable.NotNull())
            {
                configBuilder.AddJsonFile($"appsettings.{environmentVariable}.json", false);
            }

            var config = configBuilder.Build();

            var hostModel = new HostModel();
            config.GetSection("Host").Bind(hostModel);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"CreateBuilder:Start:{HostModel.Urls}");
            Console.ForegroundColor = ConsoleColor.White;

            if (HostModel.Urls.IsNull())
                HostModel.Urls = "http://*:5000";

            return hostModel;


        }
    }
}
