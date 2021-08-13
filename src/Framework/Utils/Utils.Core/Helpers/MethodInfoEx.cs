using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LiModular.Lib.Utils.Core.Helper
{
    public static class MethodInfoEx
    {
        public static async Task<object> InvokeAsync(this MethodInfo @this, object obj, params object[] parameters)
        {
            Task task = (Task)@this.Invoke(obj, parameters);
            await task.ConfigureAwait(continueOnCapturedContext: false);
            return task.GetType().GetProperty("Result").GetValue(task);
        }
    }
}
