using LiModular.Lib.Cache.Abstractions;
using LiModular.Lib.Utils.Core.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiModular.Lib.Cache.AspNetCore
{
    /// <summary>
    /// 服务
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="services"></param>
        /// <param name="cfg"></param>
        /// <returns></returns>
        public static IServiceCollection AddCache(this IServiceCollection services, IConfiguration cfg)
        {
            var config = new CacheConfig();
            var section = cfg.GetSection("Cache");
            section?.Bind(config);

            services.AddSingleton(config);
            var assembly = AssemblyHelper.LoadByNameEndString($".Lib.Cache.");

            Check.NotNull(assembly, $"缓存实现程序集()未找到");

            var handlerType = assembly.GetTypes().FirstOrDefault(m => typeof(ICacheHandler).IsAssignableFrom(m));
            if (handlerType != null)
            {
                services.AddSingleton(typeof(ICacheHandler), handlerType);
            }

            return services;
        }
    }
}