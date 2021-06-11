namespace LiModular.Lib.Utils.Core.Configuration
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Configuration.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// appsettings.json操作类
    /// </summary>
    public class Appsettings
    {
        // //Microsoft.Extensions.Configuration
        static IConfiguration Configuration { get; set; }

        public Appsettings()
        {
            var configBuilder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)  //Microsoft.Extensions.Configuration.FileExtensions
            .AddJsonFile("appsettings.json", false);             //Microsoft.Extensions.Configuration.Json   Add

            var environmentVariable = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (environmentVariable.NotNull())
            {
                configBuilder.AddJsonFile($"appsettings.{environmentVariable}.json", false);
            }
            Configuration = configBuilder.Build();
        }


        public Appsettings(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 封装要操作的字符
        /// </summary>
        /// <param name="sections">节点配置</param>
        /// <returns></returns>
        public static string App(params string[] sections)
        {
            try
            {

                if (sections.Any())
                {
                    return Configuration[string.Join(":", sections)];
                }
            }
            catch (Exception) { }

            return "";
        }


        /// <summary>
        /// 封装要操作的字符
        /// </summary>
        /// <param name="sections">节点配置</param>
        /// <returns></returns>
        public static string App(string sections)
        {
            try
            {

                if (sections.NotNull())
                {
                    return Configuration[sections];
                }
            }
            catch (Exception) { }

            return "";
        }


        /// <summary>
        /// 递归获取配置信息数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sections"></param>
        /// <returns></returns>
        public static List<T> App<T>(params string[] sections)
        {
            List<T> list = new List<T>();
            // 引用 Microsoft.Extensions.Configuration.Binder 包
            Configuration.Bind(string.Join(":", sections), list);
            return list;
        }


        public static T Bind<T>(params string[] sections)
        {
            T t = Activator.CreateInstance<T>();
            Configuration.Bind(string.Join(":", sections), t);
            return t;
        }
    }
}
