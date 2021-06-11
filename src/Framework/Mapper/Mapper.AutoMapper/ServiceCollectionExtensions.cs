using AutoMapper;
using LiModular.Lib.Module.Abstractions;
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
                foreach (var moduleInfo in modules)
                {
                    //看到时候实体转换放到那一层级里面
                    //var types = moduleInfo.AssemblyDescriptor.Application.GetTypes().Where(t => typeof(IMapperConfig).IsAssignableFrom(t));                   
                    //foreach (var type in types)
                    //{
                    //    ((IMapperConfig)Activator.CreateInstance(type)).Bind(cfg);
                    //}
                }
            });

            services.AddSingleton(config.CreateMapper());

            return services;
        }
    }
}
