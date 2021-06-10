namespace LiModular.Lib.Module.AspNetCore
{
    using LiModular.Lib.Module.Abstractions;
    using LiModular.Lib.Utils.Core.Helpers;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text.Json;

    /// <summary>
    /// 模块化集合
    /// </summary>
    public class ModuleCollection : ModuleCollectionAbstract
    {
        /// <summary>
        /// 加载模块化描述
        /// </summary>
        /// <param name="moduleDir"></param>
        /// <param name="jsonReader"></param>
        protected override void LoadDescriptor(DirectoryInfo moduleDir, StreamReader jsonReader)
        {
            var moduleDescriptor = JsonSerializer.Deserialize<ModuleDescriptor>(jsonReader.ReadToEnd());
            if (moduleDescriptor != null)
            {
                //判断是否已存在
                if (!Collection.Any(m => m.Name.Equals(moduleDescriptor.Name)))
                {
                    //加载程序集信息并将当前模块信息添加在集合
                    LoadAssemblyDescriptor(moduleDescriptor);
                    Add(moduleDescriptor);
                }
            }
        }

        /// <summary>
        /// 加载程序集信息
        /// </summary>
        private void LoadAssemblyDescriptor(ModuleDescriptor moduleDescriptor)
        {
            //此处默认模块命名空间前缀与当前项目相同
            var assemblyDescriptor = new ModuleAssemblyDescriptor
            {
                //LiModular.Module.Admin.Web
                Web = AssemblyHelper.LoadByNameEndString($"Module.{moduleDescriptor.Code}.Web"),
            };
            moduleDescriptor.AssemblyDescriptor = assemblyDescriptor;

            //加载模块初始化器
            var controllerAssembly = assemblyDescriptor.Web;
            if (controllerAssembly != null)
            {
                var initializerType = controllerAssembly.GetTypes().FirstOrDefault(t => typeof(IModuleInitializer).IsAssignableFrom(t));
                if (initializerType != null && (initializerType != typeof(IModuleInitializer)))
                {
                    moduleDescriptor.Initializer = (IModuleInitializer)Activator.CreateInstance(initializerType);
                }
            }

        }

    }
}
