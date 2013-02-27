using System;
using System.IO;

namespace Space
{
    [Version(1,0)]
    public static class PathStorage
    {
        private static Path path = new Path();

        public static Path GetPathFromFile(string filePath)
        {
            StreamReader sr = new StreamReader(filePath);
            using (sr)
            {
                Point3D currentPoint = new Point3D();
                while (!sr.EndOfStream)
                {
                    string currentLine = sr.ReadLine();
                    int value = int.Parse(currentLine.Substring(2));
                    if (currentLine[0] == 'x')
                    {
                        currentPoint = new Point3D();
                        currentPoint.XPos = value;
                    }
                    else if (currentLine[0] == 'y')
                    {
                        currentPoint.YPos = value;
                    }
                    else if (currentLine[0] == 'z')
                    {
                        currentPoint.ZPos = value;
                        path.AddPoint(currentPoint);
                    }
                }
            }
            return path;
        }
    }
}
