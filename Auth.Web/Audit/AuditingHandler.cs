//using Auth.Web;
//using Data.Abstractions.Login;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Utils.Core.Options;
//using Microsoft.AspNetCore.Mvc;
//using System.Text.Json;
//using Utils.Core;
//using Utils.Core.Attributes;
//using Auth.Web.Mvc;
//using Sys.Core.Application.AuditInfo;
//using Sys.Core.Domain.AuditInfo;

//namespace LiModular.Lib.Auth.Web.Audit
//{
//    /// <summary>
//    /// 审计日志处理
//    /// </summary>
//    [Scoped]
//    public class AuditingHandler : IAuditingHandler
//    {
//        private readonly MvcHelper _mvcHelper;
//        private readonly ILoginInfo _loginInfo;
//        private readonly IAuditInfoService _auditInfoService;
//        private readonly ILogger _logger;

//        public AuditingHandler(ILoginInfo loginInfo, IAuditInfoService auditInfoService,
//            ILogger<AuditingHandler> logger)
//        {
//            _mvcHelper = mvcHelper;
//            _loginInfo = loginInfo;
//            _auditInfoService = auditInfoService;
//            _logger = logger;
//        }

//        public async Task Hand(ActionExecutingContext context, ActionExecutionDelegate next)
//        {
//            if (!HostModel.Auditing)
//            {
//                await next();
//                return;
//            }
//            var auditInfo = CreateAuditInfo(context);
//            var sw = new Stopwatch();
//            sw.Start();

//            var resultContext = await next();

//            sw.Stop();

//            if (auditInfo != null)
//            {
//                try
//                {
//                    //用时
//                    auditInfo.ExecutionDuration = sw.ElapsedMilliseconds;

//                    await _auditInfoService.Add(auditInfo);
//                }
//                catch (Exception ex)
//                {
//                    //_logger.LogError("审计日志插入异常：{@ex}", ex);
//                }
//            }
//        }

//        private AuditInfoEntity CreateAuditInfo(ActionExecutingContext context)
//        {
//            try
//            {
//                var routeValues = context.ActionDescriptor.RouteValues;
//                var auditInfo = new AuditInfoEntity
//                {
//                    AccountId = _loginInfo.UserId,
//                    AccountName = _loginInfo.RealName,
//                    Module = HostModel.MainaAsembly,
//                    Controller = routeValues["controller"],
//                    Action = routeValues["action"],
//                    ExecutionTime = DateTime.Now
//                };              

//                //var controllerDescriptor = _mvcHelper.GetAllController().FirstOrDefault(m => m.Area.NotNull() && m.Area.EqualsIgnoreCase(auditInfo.Area) && m.Name.EqualsIgnoreCase(auditInfo.Controller));
//                //if (controllerDescriptor != null)
//                //{
//                //    auditInfo.ControllerDesc = controllerDescriptor.Description;

//                //    var actionDescription = _mvcHelper.GetAllAction().FirstOrDefault(m => m.Controller == controllerDescriptor && m.Name.EqualsIgnoreCase(auditInfo.Action));
//                //    if (actionDescription != null)
//                //    {
//                //        auditInfo.ActionDesc = actionDescription.Description;
//                //    }
//                //}

//                return auditInfo;
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError("审计日志创建异常：{@ex}", ex);
//            }

//            return null;
//        }
//    }
//}
