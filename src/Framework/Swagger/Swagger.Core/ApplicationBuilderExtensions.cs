namespace LiModular.Lib.Swagger.Core
{
    using LiModular.Lib.Module.Abstractions;
    using LiModular.Lib.Module.AspNetCore;
    using LiModular.Lib.Swagger.Core.Extensions;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Swashbuckle.AspNetCore.SwaggerUI;

    public static class ApplicationBuilderExtensions
    {
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
