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
            return $"{color.R:X2}{color.G:X2}{color.B:X2}";
        }

        public static string ToHex(byte r, byte g, byte b)
        {
            return $"#{r:X2}{g:X2}{b:X2}";
        }
    }
}
