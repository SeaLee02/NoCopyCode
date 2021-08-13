using AspectCore.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiModular.Lib.AOP.AspNetCore
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加AOP
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddAop(this IServiceCollection services)
        {

            services.ConfigureDynamicProxy(o => {
                //添加AOP的配置
            });
            return services;
        }
    }
}
