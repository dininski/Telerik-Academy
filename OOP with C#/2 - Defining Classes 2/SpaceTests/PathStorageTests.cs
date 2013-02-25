using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Space;

namespace SpaceTests
{
    [TestClass]
    public class PathStorageTests
    {
        [TestMethod]
        public void PathStorageBaseCase()
        {
            Path a = PathStorage.GetPathFromFile("../../../path.txt");
            var test = a.GetPath();
            foreach (var item in test)
            {
                Console.WriteLine(item);
            }
        }

        [TestMethod]
        [ExpectedException (typeof(System.IO.FileNotFoundException))]
        public void PathStoragePathNotFound()
        {
            Path a = PathStorage.GetPathFromFile("invalid_path.txt");
            var test = a.GetPath();
            foreach (var item in test)
            {
                Console.WriteLine(item);
            }
        }
    }
}
