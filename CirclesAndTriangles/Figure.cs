using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CirclesAndTriangles
{
    public enum FigureType
    {
        Circle,
        Triangle
    }

    public class Figure
    {
        public FigureType Type { get; private set; }
        public List<double> Sides { get; private set; }

        public Figure(FigureType type, List<double> sides)
        {
            Type = type;

            if(Type == FigureType.Triangle && sides.Count != 3)
            {
                throw new ArgumentException("Triangle must have 3 sides.");
            }

            if(Type == FigureType.Circle && sides.Count != 1)
            {
                throw new ArgumentException("Circle must have only 1 side (radius).");
            }

            foreach (var side in sides)
            {
                if(side <= 0)
                {
                    throw new ArgumentException("Side can not be less than or equal to 0.");
                }
            }

            Sides = sides;
        }

        private delegate double CalculateAreaDelegate(List<double> sides);

        private static Dictionary<FigureType, CalculateAreaDelegate> calculateAreas = new Dictionary<FigureType, CalculateAreaDelegate>
        {
            [FigureType.Circle] = (sides) => Math.PI * Math.Pow(sides[0], 2),
            [FigureType.Triangle] = (sides) =>
            {
                var semiPerimeter = (sides[0] + sides[1] + sides[2]) / 2;

                return Math.Sqrt(semiPerimeter * (semiPerimeter - sides[0]) * (semiPerimeter - sides[1]) * (semiPerimeter - sides[2]));
            }
        };

        public static double CalculateArea(Figure figure)
        {
            return calculateAreas[figure.Type](figure.Sides);
        }
    }
}
