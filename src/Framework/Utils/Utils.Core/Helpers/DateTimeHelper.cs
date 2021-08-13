using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiModular.Lib.Utils.Core.Helper
{
    public class DateTimeHelper
    {
        /// <summary>
        /// 时间戳起始日期
        /// </summary>
        public static DateTime TimestampStart = new DateTime(1970, 1, 1, 0, 0, 0, 0);

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <param name="milliseconds">是否使用毫秒</param>
        /// <returns></returns>
        public static string GetTimeStamp(bool milliseconds = false)
        {
            var ts = DateTime.UtcNow - TimestampStart;
            return Convert.ToInt64(milliseconds ? ts.TotalMilliseconds : ts.TotalSeconds).ToString();
        }

        /// <summary>
        /// 比较年月日是否相等
        /// </summary>
        /// <returns></returns>
        public static bool CompareYmd(DateTime original)
        {
            bool ret = false;
            var target = DateTime.Now;
            if (original.Year == target.Year && original.Month == target.Month && original.Day == target.Day)
            {
                ret = true;
            }
            return ret;
        }

    }
}
