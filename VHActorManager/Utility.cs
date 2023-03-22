using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace VHActorManager
{
    internal class Utility
    {
        public static string? ExecDirectory()
        {
            return Directory.GetParent(Assembly.GetExecutingAssembly().Location)?.FullName;
        }

        public static string ExecFilepath(string fileName)
        {
            string? dir = ExecDirectory();

            if (dir == null) { 
                return CurrentFilePath(fileName);
            }

            return Path.Combine(dir, fileName);
        }

        public static string CurrentFilePath(string fileName)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), fileName);
        }
    }
}
