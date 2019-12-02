using System;
using System.Collections.Generic;
using System.Linq;

namespace PiApproximator
{
    // PIApproximater takes at most [long] number of points. Comportment is not consistent above it
    public class PIApproximator
    {
        private IEnumerable<Point> collection;

        public PIApproximator(IEnumerable<Point> randColection)
        {
            collection = randColection;
        }

        public PIApproximator()
        {
        }

        public double Approximate()
        {
            long numberInCollection = collection.LongCount();

            if (numberInCollection == 0)
                throw new Exception();

            long numberInCollectionInsideRadius = GetNumberInCollectionInsideRadius();
            return InferPIFromProbability(ComputeProbabilityPointInsideRadius(numberInCollection, numberInCollectionInsideRadius));
        }

        private double InferPIFromProbability(double probabilityPointInsideRadius)
        {
            // prob = PI / 4
            // prob * 4 = ~PI
            return probabilityPointInsideRadius * 4;
        }

        public IEnumerable<Point> GeneratePoints(long numberOfPointsToGenerate)
        {
            List<Point> randCollection = new List<Point>();
            for (int i = 0; i < numberOfPointsToGenerate; i++)
            {
                randCollection.Add(Point.NewPoint());
            }
            return randCollection;
        }

        public void AddPoints(IEnumerable<Point> points)
        {
            if (collection == null)
                collection = new List<Point>();
            ((List<Point>)collection).AddRange(points);
        }

        private double ComputeProbabilityPointInsideRadius(long numberInCollection, long numberInCollectionInsideRadius)
        {
            return (double)numberInCollectionInsideRadius / (double)numberInCollection;
        }

        private long GetNumberInCollectionInsideRadius()
        {
            long count = 0;
            foreach (Point point in  collection)
            {
                if (point.InsideRadius())
                    count++;
            }
            return count;
        }
    }
}