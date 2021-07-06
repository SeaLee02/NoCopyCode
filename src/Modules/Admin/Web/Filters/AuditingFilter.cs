using System.Linq;
using System.Threading.Tasks;
using LiModular.Lib.Module.AspNetCore.Attributes;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LiModular.Module.Admin.Web.Filters
{
    /// <summary>
    /// 审计过滤器
    /// </summary>
    public class AuditingFilter : IAsyncActionFilter
    {
        private readonly IAuditingHandler _handler;

        public AuditingFilter(IAuditingHandler handler)
        {
            _handler = handler;
        }

        public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {         
            if ( CheckDisabled(context))
            {
                return next();
            }

            return _handler.Hand(context, next);
        }

        /// <summary>
        /// 判断是否禁用审计功能
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private bool CheckDisabled(ActionExecutingContext context)
        {
            return context.ActionDescriptor.EndpointMetadata.Any(m => m.GetType() == typeof(DisableAuditingAttribute));
        }
    }
}
