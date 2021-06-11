namespace LiModular.Lib.Host.Web.Middleware
{
    using Microsoft.AspNetCore.Builder;


    public static class ExceptionHandleMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandle(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandleMiddleware>();

            return app;
        }
    }
}