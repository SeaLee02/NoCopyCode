using AspectCore.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiModular.Lib.Module.AspNetCore.AOP
{
    /// <summary>
    /// 事物
    /// </summary>
    public class TransactionInterceptorAttribute: AbstractInterceptorAttribute
    {



        public override Task Invoke(AspectContext context, AspectDelegate next)
        {
            Console.WriteLine("call interceptor");
            return context.Invoke(next);
        }


    }
}
