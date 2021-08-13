namespace LiModular.WebHost
{
    using LiModular.Lib.Host.Web;

    /// <summary>
    /// 开始程序
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 入口
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            new HostBootstrap(args).Run<Startup>();
        }
    }
}
