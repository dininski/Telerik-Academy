using System;

class ReadFile
{
    public static string ReadAFile(string path)
    {
        string content = System.IO.File.ReadAllText(path);
        return content;
    }

    static void Main(string[] args)
    {

        try
        {
            string fileContent = ReadAFile(@"C:\Windows\win.ini");
            Console.WriteLine(fileContent);
        }
        catch (System.IO.PathTooLongException)
        {
            Console.WriteLine("The path is too long");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("The path is null");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Path is zero-length, contains only whitespace or is contains invalid data");
        }
        catch (System.IO.DirectoryNotFoundException)
        {
            Console.WriteLine("The specified path is invalid");
        }
        catch (System.IO.FileNotFoundException)
        {
            Console.WriteLine("File not found in the specified directory");
        }
        catch (System.IO.IOException)
        {
            Console.WriteLine("An input/output error occured while opening the file");
        }
        catch (System.UnauthorizedAccessException)
        {
            Console.WriteLine("File is read-only, the operation is not supported on this platform, directory was specified or unsifficient permissions");
        }
        catch (System.NotSupportedException)
        {
            Console.WriteLine("Path is in invalid format");
        }
        catch (System.Security.SecurityException)
        {
            Console.WriteLine("Insufficient permissions");
        }

    }
}