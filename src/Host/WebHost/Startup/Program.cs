namespace LiModular.WebHost
{
    using LiModular.Lib.Host.Web;

    /// <summary>
    /// ��ʼ����
    /// </summary>
    public class Program
    {
        /// <summary>
        /// ���
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            new HostBootstrap(args).Run<Startup>();
        }
    }
}
