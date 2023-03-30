using System.Reflection;

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

        public static string GetDocumentFolderPath()
        {
            return System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        public static string CombineFilePath(string dirName, string fileName)
        {
            return Path.Combine(dirName, fileName);
        }

        public static string GetDirectory(string filePath)
        {
            return Path.GetDirectoryName(filePath) ?? "";
        }

        public static string ToHex(Color color)
        {
            return string.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);
        }

        public static string ToHex(byte r, byte g, byte b)
        {
            return string.Format("#{0:X2}{1:X2}{2:X2}", r, g, b);
        }
    }
}
