using AspectCore.DynamicProxy;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LiModular.Lib.AOP.AspNetCore.Lock
{

    public class LockedAttribute : AbstractInterceptorAttribute
    {
        //使用参考 EmpEducationalExperienceService
        private int maximum_concurrency_number;
        //private static ConcurrentDictionary<int, SemaphoreSlim> SemaphoreSlimRepo = new ConcurrentDictionary<int, SemaphoreSlim>();
        public LockedAttribute(int maximumConcurrencyNumber)
        {
            maximum_concurrency_number = maximumConcurrencyNumber;
        }


        public async override Task Invoke(AspectContext context, AspectDelegate next)
        {
            SemaphoreSlim semaphore = new SemaphoreSlim(maximum_concurrency_number);
            await semaphore.WaitAsync();
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally {
                semaphore.Release();
            }
        }
    }
}