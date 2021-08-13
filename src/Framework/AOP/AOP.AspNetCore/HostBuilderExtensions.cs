using AspectCore.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiModular.Lib.AOP.AspNetCore
{
    public static class HostBuilderExtensions
    {
        /// <summary>
        /// 用AspectCore替换默认的IOC容器
        /// </summary>
        /// <param name="hostBuilder"></param>
        /// <returns></returns>
        public static IHostBuilder AddAspCoreIoc(this IHostBuilder hostBuilder)
        {
            hostBuilder.UseServiceProviderFactory(new DynamicProxyServiceProviderFactory());

            return hostBuilder;
        }


    }
}
