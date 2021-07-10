using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Files.Challenges
{
    public class First
    {
        public static void Solution()
        {
            IEnumerable<string> salesFiles = FindFiles("stores");
            salesFiles.ToList().ForEach(LogFile);
            Console.WriteLine(new string('-', 35));
        }

        private static void LogFile(string file)
        {
            var info = new FileInfo(file);
            Console.WriteLine(new string('-', 35));
            Console.WriteLine(
                $"Full Name: {info.FullName}{Environment.NewLine}Directory:" +
                $" {info.Directory}{Environment.NewLine}Extension: " +
                $"{info.Extension}{Environment.NewLine}Create Date: {info.CreationTime}");
        }

        private static IEnumerable<string> FindFiles(string folderName)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string fullPath =
                Path.Combine(currentDirectory, "Challenges", folderName);

            LogDirectory(fullPath);
            IEnumerable<string> foundFiles =
                Directory.EnumerateFiles(fullPath, "*",
                    SearchOption.AllDirectories);

            return foundFiles.Where(file => Path.GetExtension(file) == ".json");
        }

        private static void LogDirectory(string path)
        {
            var info = new DirectoryInfo(path);
            Console.WriteLine(new string('-', 35));
            Console.WriteLine(
                $"Directory Name: {info.FullName}{Environment.NewLine}Directory:" +
                $" {info.Parent}{Environment.NewLine}Create Date: {info.CreationTime}\n"
            );
        }
    }
}
