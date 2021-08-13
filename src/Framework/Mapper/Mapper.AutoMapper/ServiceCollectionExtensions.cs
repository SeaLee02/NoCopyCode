using AutoMapper;
using LiModular.Lib.Module.Abstractions;
using LiModular.Lib.Utils.Core.Annotations;
using LiModular.Lib.Utils.Core.Helpers;
using LiModular.Lib.Utils.Core.Options;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiModular.Lib.Mapper.AutoMapper
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加对象映射
        /// </summary>
        /// <param name="services"></param>
        /// <param name="modules">模块集合</param>
        /// <returns></returns>
        public static IServiceCollection AddMappers(this IServiceCollection services, IModuleCollection modules)
        {
            var config = new MapperConfiguration(cfg =>
            {
                //走配置管理
                foreach (var moduleInfo in modules)
                {
                    //注册公共的Service服务
                    var services = moduleInfo.AssemblyDescriptor.Application.GetTypes().Where(t => typeof(IMapperConfig).IsAssignableFrom(t));
                    if (services != null)
                    {
                        foreach (var service in services)
                        {
                            ((IMapperConfig)Activator.CreateInstance(service)).Bind(cfg);
                        }
                    }
                }
                //走特性映射
                foreach (var moduleInfo in modules)
                {
                    var types = moduleInfo.AssemblyDescriptor.Application.GetTypes();
                    foreach (var type in types)
                    {
                        var map = (ObjectMapAttribute)Attribute.GetCustomAttribute(type, typeof(ObjectMapAttribute));
                        if (map != null)
                        {
                            cfg.CreateMap(type, map.TargetType);

                            if (map.TwoWay)
                            {
                                cfg.CreateMap(map.TargetType, type);
                            }
                        }
                    }
                }
            });
            //注入官方方法
            services.AddSingleton(config.CreateMapper());
            services.AddSingleton<Utils.Core.Map.IObjectMapper, DefaultMapper>();






            //var config = new MapperConfiguration(cfg =>
            //{
            //    foreach (var moduleInfo in modules)
            //    {
            //        //看到时候实体转换放到那一层级里面
            //        //var types = moduleInfo.AssemblyDescriptor.Application.GetTypes().Where(t => typeof(IMapperConfig).IsAssignableFrom(t));                   
            //        //foreach (var type in types)
            //        //{
            //        //    ((IMapperConfig)Activator.CreateInstance(type)).Bind(cfg);
            //        //}
            //    }
            //});

            //services.AddSingleton(config.CreateMapper());

            return services;
        }
    }
}
