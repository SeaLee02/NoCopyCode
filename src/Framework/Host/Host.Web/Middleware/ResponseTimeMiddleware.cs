using LiModular.Lib.Utils.Core.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiModular.Lib.Host.Web.Middleware
{
    public class ResponseTimeMiddleware
    {
        // Name of the Response Header, Custom Headers starts with "X-"  
        private const string RESPONSE_HEADER_RESPONSE_TIME = "X-Response-Time-ms";
        // Handle to the next Middleware in the pipeline  
        private readonly RequestDelegate _next;
        public ResponseTimeMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var request = context.Request;
            request.EnableBuffering();

            // Start the Timer using Stopwatch  
            var watch = new Stopwatch();
            watch.Start();
            string sTime = DateTimeHelper.GetTimeStamp(true);

            context.Response.OnStarting(() => {
                // Stop the timer information and calculate the time   
                watch.Stop();
                string eTime = DateTimeHelper.GetTimeStamp(true);
                var responseTimeForCompleteRequest = watch.ElapsedMilliseconds;
                // Add the Response time information in the Response headers.   
                context.Response.Headers[RESPONSE_HEADER_RESPONSE_TIME] = responseTimeForCompleteRequest.ToString();

                //var requestStr = $"{request.Scheme} {request.Host} {request.Path} {request.QueryString} {sTime} {eTime} {watch.ElapsedMilliseconds}";
                //_logger.LogError("Request:" + requestStr);

                return Task.CompletedTask;
            });
            // Call the next delegate/middleware in the pipeline   
            await this._next.Invoke(context);
        }
    }
}
