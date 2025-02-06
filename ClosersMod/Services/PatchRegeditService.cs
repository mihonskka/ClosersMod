using ClosersFramework.Service.CodeManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ClosersFramework.Service
{
    [NoReference]
    public static class PatchRegeditService
    {
        public static List<Assembly> AssembliesList = new List<Assembly>();
        public static void AddAssembly(Assembly assembly)
        {
            AssembliesList.Add(assembly);
        }

    }
}
