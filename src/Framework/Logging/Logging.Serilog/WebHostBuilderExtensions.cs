using Microsoft.AspNetCore.Hosting;
using Serilog;

namespace LiModular.Lib.Logging.Serilog
{
    public static class WebHostBuilderExtensions
    {
        /// <summary>
        /// 日志
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IWebHostBuilder UseLogging(this IWebHostBuilder builder)
        {
            //配置文件种使用
            builder.UseSerilog((hostingContext, loggerConfiguration) =>
            {
                loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration).Enrich.FromLogContext();
            });

            return builder;
        }
    }
}
