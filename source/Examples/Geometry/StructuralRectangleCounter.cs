namespace bbv.Examples.Geometry
{
    using System;
    using System.Linq;

    public class StructuralRectangleCounter : ICountRectangles
    {
        /// <inheritdoc />
        public int CountIn(int[,] pointSequence)
        {
            int numberOfRectanglesFound = 0;
            var sortedPoints = SortPoints(pointSequence);

            foreach (var point in sortedPoints)
            {
                var pointsAbove = FindPointsAboveOf(point, sortedPoints);
                var pointsToTheRight = FindPointsRightOf(point, sortedPoints);

                foreach (var pointAbove in pointsAbove)
                {
                    foreach (var pointToTheRight in pointsToTheRight)
                    {
                        var expectedFourthRectanglePoint = new Point(pointAbove[0], pointToTheRight[1]);
                        if (sortedPoints.Contains(expectedFourthRectanglePoint))
                        {
                            numberOfRectanglesFound++;
                        }
                    }
                }
            }

            return numberOfRectanglesFound;
        }

        private static int[,] FindPointsAboveOf(int[] startingPoint, int[,] sortedPoints)
        {
            return sortedPoints
                .Where<int[]>(p => p[0] == startingPoint[0])
                .Where<int[]>(p => p[1] > startingPoint[1]);
        }

        private static int[,] FindPointsRightOf(int[,] startingPoint, int[,] sortedPoints)
        {
            return sortedPoints
                .Where(p => p[1] == startingPoint[1])
                .Where(p => p[0] > startingPoint[0])
                .ToArray();
        }

        private static int[,] SortPoints(int[,] unsortedPoints)
        {
            var sortedPoints = (int[,])unsortedPoints.Clone();
            Array.Sort(sortedPoints);
            return sortedPoints;
        }
    }
}