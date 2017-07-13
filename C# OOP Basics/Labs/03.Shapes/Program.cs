using System;

namespace _03.Shapes
{
    public class Program
    {
        public static void Main()
        {
            Circle circle = new Circle(5);

            Console.WriteLine(circle.CalculatePerimeter());
            Console.WriteLine(circle.CalculateArea());
        }
    }
}