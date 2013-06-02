namespace DisplayExeFiles
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    public class Program
    {
        public static void Main(string[] args)
        {
            DirectoryInfo windowsRoot = new DirectoryInfo("C:\\Windows");
            Queue<DirectoryInfo> subDirectories = new Queue<DirectoryInfo>();
            subDirectories.Enqueue(windowsRoot);
            int exeFilesCount = 0;

            while (subDirectories.Count != 0)
            {
                var currentDir = subDirectories.Dequeue();
                try
                {
                    var currentDirFiles = currentDir.EnumerateFiles();
                    var currentDirSubdirs = currentDir.EnumerateDirectories();
                    foreach (var file in currentDirFiles)
                    {
                        string fileString = file.Name;
                        var regex = new Regex("^(.*\\.exe)$");
                        if (regex.IsMatch(fileString))
                        {
                            Console.WriteLine(fileString);
                            exeFilesCount++;
                        }
                    }

                    foreach (var subDir in currentDirSubdirs)
                    {
                        subDirectories.Enqueue(subDir);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                }
            }

            Console.WriteLine(".exe files count: {0}", exeFilesCount);
        }
    }
}
