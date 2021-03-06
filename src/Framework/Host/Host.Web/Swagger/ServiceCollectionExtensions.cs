using LiModular.Lib.Host.Web.Swagger.Extensions;
using LiModular.Lib.Host.Web.Swagger.Filters;
using LiModular.Lib.Module.Abstractions;
using LiModular.Lib.Module.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiModular.Lib.Host.Web.Swagger
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加Swagger
        /// </summary>
        /// <param name="services"></param>
        /// <param name="modules">模块集合</param>
        /// <returns></returns>
        public static IServiceCollection AddSwagger(this IServiceCollection services, IModuleCollection modules)
        {
            services.AddSwaggerGen(c =>
            {
                if (modules != null)
                {
                    foreach (var module in modules)
                    {
                        if (((ModuleDescriptor)module).Initializer == null)
                            continue;

                        foreach (var g in module.GetGroups())
                        {
                            c.SwaggerDoc(g.Key, new OpenApiInfo
                            {
                                Title = g.Value,
                                Version = module.Version
                            });
                        }
                    }
                }

                //描述信息处理,因为多个项目,xml文件不好
                c.DocumentFilter<DescriptionDocumentFilter>();
                //// 开启加权小锁
                c.OperationFilter<AddResponseHeadersFilter>();
                c.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();

                //// 在header中添加token，传递到后台
                c.OperationFilter<SecurityRequirementsOperationFilter>();

                // Jwt Bearer 认证，必须是 oauth2
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey
                });



            });
            return services;
        }

        /// <summary>
        /// 自定义Swagger
        /// </summary>
        /// <param name="app"></param>
        /// <param name="pathBase"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseCustomSwagger(this IApplicationBuilder app, string pathBase = null)
        {
            var modules = app.ApplicationServices.GetService<IModuleCollection>();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                if (modules == null) return;

                foreach (var module in modules)
                {
                    if (((ModuleDescriptor)module).Initializer == null)
                        continue;

                    foreach (var g in module.GetGroups())
                    {
                        var url = $"/swagger/{g.Key}/swagger.json";
                        c.SwaggerEndpoint(pathBase.NotNull() ? $"{pathBase}{url}" : url, g.Value);
                    }
                }

                //启用过滤
                c.EnableFilter();

                //是否展开
                c.DocExpansion(DocExpansion.None);
                //model删除
                c.DefaultModelsExpandDepth(-1);
            });
            return app;
        }

    }
}
