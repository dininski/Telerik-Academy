namespace FilesystemTree
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;

    public class Program
    {
        public static void Main(string[] args)
        {
            DirectoryInfo rootDirectory = new DirectoryInfo("C:\\Windows");
            Console.WriteLine("Building tree...");
            var treeFolder = BuildTree(rootDirectory);

            NumberFormatInfo numberFormat = 
                (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();

            numberFormat.NumberGroupSeparator = ",";
            
            Console.WriteLine("The size of all files using recursive tree traversal is: {0} bytes",
                treeFolder.CalculateSize().ToString("N0",numberFormat));
        }

        public static Folder BuildTree(DirectoryInfo root)
        {
            string directoryName = root.ToString();
            List<File> directoryFiles = new List<File>();
            List<Folder> subdirs = new List<Folder>();

            try
            {
                var currentFiles = root.GetFiles();
                foreach (var file in currentFiles)
                {
                    directoryFiles.Add(new File(file.Name, (int)(file.Length)));
                }

                var currentSubdirectories = root.GetDirectories();
                foreach (var subdirectory in currentSubdirectories)
                {
                    subdirs.Add(BuildTree(subdirectory));
                }
            }
            catch (UnauthorizedAccessException)
            {
            }

            return new Folder(directoryName, directoryFiles.ToArray(), subdirs.ToArray());
        }
    }
}
