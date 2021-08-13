using AspectCore.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace LiModular.Lib.AOP.AspNetCore.UnitWork
{
    /// <summary>
    /// 为工作单元提供事务一致性
    /// </summary>
    public class TransactionInterceptorAttribute : AbstractInterceptorAttribute
    {
        //使用参考 EmpEducationalExperienceService
        //IUnitOfWork _unitOfWork { get; set; }

        public async override Task Invoke(AspectContext context, AspectDelegate next)
        {
            try
            {
                //_unitOfWork = context.ServiceProvider.GetService<IUnitOfWork>();
                //_unitOfWork.BeginTran();
                await next(context);
                //_unitOfWork.CommitTran();
            }
            catch (Exception ex)
            {
                //_unitOfWork.RollbackTran();
                throw ex;
            }
        }
    }
}