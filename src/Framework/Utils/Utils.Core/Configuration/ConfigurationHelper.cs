using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiModular.Lib.Utils.Core.Configuration
{
    /// <summary>
    /// 配置帮助类
    /// </summary>
    public class ConfigurationHelper
    {
        public static IConfiguration GetConfig()
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
            return config;
        }
    }
}
