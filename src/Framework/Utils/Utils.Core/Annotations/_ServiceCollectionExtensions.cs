namespace LiModular.Lib.Utils.Core.Attributes
{
    using LiModular.Lib.Utils.Core.Helpers;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public static class ServiceCollectionExtensions2
    {
        /// <summary>
        /// 从指定程序集中注入服务
        /// </summary>
        /// <param name="services"></param>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static IServiceCollection AddServicesFromAssembly(this IServiceCollection services, Assembly assembly)
        {
            foreach (var type in assembly.GetTypes())
            {
                #region ==单例注入==

                var singletonAttr = (SingletonAttribute)Attribute.GetCustomAttribute(type, typeof(SingletonAttribute));
                if (singletonAttr != null)
                {
                    //注入自身类型
                    if (singletonAttr.Itself)
                    {
                        services.AddSingleton(type);
                        continue;
                    }

                    var interfaces = type.GetInterfaces().Where(m => m != typeof(IDisposable)).ToList();
                    if (interfaces.Any())
                    {
                        foreach (var i in interfaces)
                        {
                            services.AddSingleton(i, type);
                        }
                    }
                    else
                    {
                        services.AddSingleton(type);
                    }

                    continue;
                }

                #endregion

                #region ==瞬时注入==

                var transientAttr = (TransientAttribute)Attribute.GetCustomAttribute(type, typeof(TransientAttribute));
                if (transientAttr != null)
                {
                    //注入自身类型
                    if (transientAttr.Itself)
                    {
                        services.AddSingleton(type);
                        continue;
                    }

                    var interfaces = type.GetInterfaces().Where(m => m != typeof(IDisposable)).ToList();
                    if (interfaces.Any())
                    {
                        foreach (var i in interfaces)
                        {
                            services.AddTransient(i, type);
                        }
                    }
                    else
                    {
                        services.AddTransient(type);
                    }
                    continue;
                }

                #endregion

                #region ==Scoped注入==
                var scopedAttr = (ScopedAttribute)Attribute.GetCustomAttribute(type, typeof(ScopedAttribute));
                if (scopedAttr != null)
                {
                    //注入自身类型
                    if (scopedAttr.Itself)
                    {
                        services.AddSingleton(type);
                        continue;
                    }

                    var interfaces = type.GetInterfaces().Where(m => m != typeof(IDisposable)).ToList();
                    if (interfaces.Any())
                    {
                        foreach (var i in interfaces)
                        {
                            services.AddScoped(i, type);
                        }
                    }
                    else
                    {
                        services.AddScoped(type);
                    }
                }

                #endregion
            }

            return services;
        }

        /// <summary>
        /// 注入所有服务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServicesFromAttribute(this IServiceCollection services)
        {
            var assemblies = AssemblyHelper.Load();
            foreach (var assembly in assemblies)
            {
                try
                {
                    services.AddServicesFromAssembly(assembly);
                }
                catch
                {
                    //此处防止第三方库抛出一场导致系统无法启动，所以需要捕获异常来处理一下
                }
            }
            return services;
        }
    }
}
