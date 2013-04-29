namespace CohesionAndCoupling.Utils
{
    /// <summary>
    /// Utilities that provide you with a file's extension or
    /// filename without the extension
    /// </summary>
    public static class FileSystemUtils
    {
        /// <summary>
        /// Returns the extension of <paramref name="fileName"/>
        /// </summary>
        /// <param name="fileName">A file name</param>
        /// <returns>Returns the file extension</returns>
        public static string GetFileExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return string.Empty;
            }

            string extension = fileName.Substring(indexOfLastDot + 1);
            return extension;
        }

        /// <summary>
        /// Returns the name of <paramref name="fileName"/> without
        /// the file extension
        /// </summary>
        /// <param name="fileName">A file name</param>
        /// <returns>Returns the filename without extension</returns>
        public static string GetFileNameWithoutExtension(string fileName)
        {
            int indexOfLastDot = fileName.LastIndexOf(".");
            if (indexOfLastDot == -1)
            {
                return fileName;
            }

            string extension = fileName.Substring(0, indexOfLastDot);
            return extension;
        }
    }
}
