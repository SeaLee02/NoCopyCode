namespace LiModular.Lib.Module.AspNetCore
{
    using LiModular.Lib.Module.Abstractions;
    using System.Reflection;

    /// <summary>
    /// DDD层级项目,用于注入
    /// </summary>
    public class ModuleAssemblyDescriptor : IModuleAssemblyDescriptor
    {
        /// <summary>
        /// Web项目
        /// </summary>
        public Assembly Web { get; set; }

        /// <summary>
        /// 应用层
        /// </summary>
        public Assembly Application { get; set; }

    }
}
