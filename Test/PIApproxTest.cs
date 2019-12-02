using System;
using System.Collections.Generic;
using Xunit;
using PiApproximator;

namespace Test
{
    public class PIApproxTest
    {
        [Fact]
        public void PIApproximator_AddEmptyPoints_ShouldThrow()
        {
            Point[] randCollection = new Point[] { };
            PIApproximator pia = new PIApproximator(randCollection);

            Assert.Throws<Exception>(() => pia.Approximate());
        }

        [Fact]
        public void PIApproximator_AddTenPoints_ShouldNotThrow()
        {
            List<Point> randCollection = new List<Point>();
            for (int i = 0; i < 10; i++)
            {
                randCollection.Add(Point.NewPoint());
            }
            PIApproximator pia = new PIApproximator(randCollection.ToArray());
            pia.Approximate();
        }

        [Fact]
        public void PIApproximator_GenerateTenPoints_ShouldReturnTenPointsEnumerable()
        {
            PIApproximator pia = new PIApproximator();
            List<Point> points = pia.GeneratePoints(10) as List<Point>;
            Assert.Equal(10, points.Count);
        }

        [Fact]
        public void PIApproximator_ApproximateFromAHundredPoints_LateAssignment()
        {
            PIApproximator pia = new PIApproximator();
            List<Point> points = pia.GeneratePoints(10) as List<Point>;
            pia.AddPoints(points);
            double piApproximation = pia.Approximate();
        }

        [Fact]
        public void PIApproximator_TwoPoints_ShouldBeDifferent()
        {
            var newPointA = Point.NewPoint();
            var newPointB = Point.NewPoint();
            Assert.NotEqual(newPointA, newPointB);
        }

        [Fact]
        public void PIApproximator_ThreePoints_ShouldBeDifferent()
        {
            var newPointA = Point.NewPoint();
            var newPointB = Point.NewPoint();
            var newPointC = Point.NewPoint();
            Assert.NotEqual(newPointA, newPointB);
            Assert.NotEqual(newPointA, newPointC);
            Assert.NotEqual(newPointC, newPointB);
        }

        [Fact]
        public void PIApproximator_Approximate_ApproximationInferiorTo4()
        {
            List<Point> randCollection = new List<Point>();
            for (int i = 0; i < 10000000; i++)
            {
                randCollection.Add(Point.NewPoint());
            }
            PIApproximator pia = new PIApproximator(randCollection.ToArray());
            double piApprox = pia.Approximate();
            Assert.True(piApprox < 4);
        }

        [Fact]
        public void PIApproximator_Approximate_ApproximationOver2()
        {
            List<Point> randCollection = new List<Point>();
            for (int i = 0; i < 10000000; i++)
            {
                randCollection.Add(Point.NewPoint());
            }
            PIApproximator pia = new PIApproximator(randCollection.ToArray());
            double piApprox = pia.Approximate();
            Assert.True(piApprox > 2);
        }

        [Fact]
        public void PIApproximator_Approximate_ApproximationAround3dot14()
        {
            List<Point> randCollection = new List<Point>();
            for (long i = 0; i < 10000000; i++)
            {
                randCollection.Add(Point.NewPoint());
            }
            PIApproximator pia = new PIApproximator(randCollection.ToArray());
            double piApprox = pia.Approximate();

            // approximation around Math.PI
            Assert.True(piApprox >= (Math.PI - (Math.PI * 0.1)));
            Assert.True(piApprox <= (Math.PI + (Math.PI * 0.1)));
        }
    }
}
