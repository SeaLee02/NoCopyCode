namespace LiModular.Lib.Host.Web
{
    using LiModular.Lib.AOP.AspNetCore;
    using LiModular.Lib.Host.Web.Middleware;
    using LiModular.Lib.Host.Web.Swagger;
    using LiModular.Lib.Mapper.AutoMapper;
    using LiModular.Lib.Module.AspNetCore;
    using LiModular.Lib.Utils.Core.Attributes;
    using LiModular.Lib.Utils.Core.Configuration;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;


    /// <summary>
    /// 启动配置类基类
    /// </summary>
    public abstract class StartupAbstract
    {
        protected readonly IHostEnvironment _env;
        private readonly IConfiguration _cfg;


        protected StartupAbstract(IHostEnvironment env, IConfiguration cfg)
        {
            _env = env;
            _cfg = cfg;
        }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            //注册所以的自定义服务服务,属性注入
            services.AddServicesFromAttribute();

            //初始化模块数据
            var module = services.AddModules();

            //管理全局配置文件
            services.AddSingleton(new Appsettings(_cfg));

            //上下文,获取当前等人信息使用,需要显示声明
            services.AddHttpContextAccessor();        

            //添加Swagger配置
            services.AddSwagger(module);

            //配置接口映射
            //读取配置
            services.AddMappers(module);

            //使用AOP
            services.AddAop();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        }

        public virtual void Configure(IApplicationBuilder app, IHostApplicationLifetime appLifetime)
        {
            //异常处理
            app.UseExceptionHandle();
            app.UseMiddleware<ResponseTimeMiddleware>();
            app.UseCustomSwagger();
         
            app.UseCors("default");//将跨域配置放入管道
            //路由
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                 name: "default",
                 pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "areas", "areas",
                    pattern: "api/{area:exists}/{controller=Home}/{action=Index}/{id?}");

            });
            app.UseModules(_env);


        }
    }
}
