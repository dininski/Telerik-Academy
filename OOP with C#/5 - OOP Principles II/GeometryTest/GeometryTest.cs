using System;
using Geometry;

//Define abstract class Shape with only one abstract method 
//CalculateSurface() and fields width and height. Define two new 
//classes Triangle and Rectangle that implement the virtual method 
//and return the surface of the figure (height*width for rectangle 
//and height*width/2 for triangle). Define class Circle and suitable 
//constructor so that at initialization height must be kept equal to 
//width and implement the CalculateSurface() method. Write a program 
//that tests the behavior of  the CalculateSurface() method for 
//different shapes (Circle, Rectangle, Triangle) stored in an array

namespace GeometryTest
{
    class GeometryTest
    {
        static void Main()
        {
            Shape[] someShapes = new Shape[6];
            someShapes[0] = new Rectangle(5, 6);
            someShapes[1] = new Triangle(5, 6);
            someShapes[2] = new Circle(4);
            someShapes[3] = new Triangle(11, 7);
            someShapes[4] = new Rectangle(5, 6);
            someShapes[5] = new Circle(15);


            foreach (Shape shape in someShapes)
            {
                Console.WriteLine("Shape type: {0} \nSurface: {1}", shape.GetType(), shape.CalculateSurface());
                Console.WriteLine();
            }
        }
    }
}
