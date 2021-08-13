using LiModular.Lib.Module.Abstractions;
using LiModular.Lib.Module.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiModular.Lib.Host.Web.Swagger.Extensions
{
    internal static class ModuleDescriptorExtensions
    {
        public static Dictionary<string, string> GetGroups(this IModuleDescriptor descriptor)
        {
            var dictionary = new Dictionary<string, string>
            {
                {
                    descriptor.Code,
                    descriptor.Name
                }
            };
            var moduleAssemblyDescriptor = (ModuleAssemblyDescriptor)descriptor.AssemblyDescriptor;
            var controllerTypes = moduleAssemblyDescriptor.Web.GetTypes()
                .Where(m => m.Name.EndsWith("Controller"));

            foreach (var type in controllerTypes)
            {
                var array = type.FullName.Split('.');
                if (array.Length == 7)
                {
                    string text = array[5];
                    var key = descriptor.Code + "_" + text;
                    if (text != "Controllers" && !dictionary.ContainsKey(key))
                    {
                        dictionary.Add(key, descriptor.Name + "_" + text);
                    }
                }
            }
            return dictionary;
        }
    }
}
