using System;

namespace PiApproximator
{
    class Program
    {
        static void Main(string[] args)
        {
            long numberOfPoints = long.Parse(Console.ReadLine());
            PIApproximator pia = new PIApproximator();
            pia.AddPoints(pia.GeneratePoints(numberOfPoints));
            Console.WriteLine(pia.Approximate());
            Console.ReadLine();
        }
    }
}
