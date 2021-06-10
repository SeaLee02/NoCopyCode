namespace LiModular.Lib.Module.Abstractions
{
    using LiModular.Lib.Utils.Core.Abstracts;
    using System;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// 抽象集合抽象类
    /// </summary>
    public abstract class ModuleCollectionAbstract : CollectionAbstract<IModuleDescriptor>, IModuleCollection
    {
        /// <summary>
        /// 加载模块
        /// </summary>
        /// <param name="moduleDir"></param>
        /// <param name="jsonReader"></param>
        protected abstract void LoadDescriptor(DirectoryInfo moduleDir, StreamReader jsonReader);


        /// <summary>
        /// 加载集合
        /// </summary>
        public void Load()
        {
            //先清空所有的集合
            Collection.Clear();

            //读取json文件
            var modulesRootDirPath = Path.Combine(AppContext.BaseDirectory, "_modules");
            if (!Directory.Exists(modulesRootDirPath))
                return;

            var modulesRootDir = new DirectoryInfo(modulesRootDirPath);
            var moduleDirs = modulesRootDir.GetDirectories();
            if (!moduleDirs.Any())
                return;

            foreach (var moduleDir in moduleDirs)
            {
                //从_module.json文件中读取模块信息
                var jsonPath = Path.Combine(moduleDir.FullName, "_module.json");
                if (!File.Exists(jsonPath))
                    continue;

                using var jsonReader = new StreamReader(jsonPath);
                LoadDescriptor(moduleDir, jsonReader);
            }
        }
    }
}
