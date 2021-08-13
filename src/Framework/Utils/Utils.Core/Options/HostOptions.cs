using System.Collections.Generic;

namespace LiModular.Lib.Utils.Core.Options
{
    /// <summary>
    /// 主机配置项
    /// </summary>
    public class HostModel
    {
        /// <summary>
        /// 绑定的地址(默认：http://*:5000)
        /// </summary>
        public  static string Urls { get; set; } = "http://*:5000";

        public static string Version { get; set; } = "1.1";
        public static string Name { get; set; } = "接口列表";

        public static List<string> Service { get; set; }

        public static List<string> Repository { get; set; }

        public static string MainaAsembly { get; set; } = "";

        public static bool Auditing { get; set; } = false;

    }
}
