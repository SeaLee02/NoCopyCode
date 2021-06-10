namespace LiModular.Lib.Module.Abstractions
{
    using System.Collections.Generic;

    /// <summary>
    /// 模块集合
    /// </summary>
    public interface IModuleCollection : IList<IModuleDescriptor>
    {
        /// <summary>
        /// 加载
        /// </summary>
        void Load();
    }
}
