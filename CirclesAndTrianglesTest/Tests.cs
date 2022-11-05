using CirclesAndTriangles;

namespace CirclesAndTrianglesTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Circle_With2Sides_ThrowsArgumentException()
        {
            List<double> sides = new List<double> { 5, 2 };

            TestDelegate res = () =>
            {
                Figure circle = new Figure(FigureType.Circle, sides);
            };

            Assert.Throws<ArgumentException>(res);
        }

        [Test]
        public void Triangle_WithNegativeSide_ThrowsArgumentException()
        {
            List<double> sides = new List<double> { -1, 2, 3 };

            TestDelegate res = () =>
            {
                Figure triangle = new Figure(FigureType.Triangle, sides);
            };

            Assert.Throws<ArgumentException>(res);
        }

        [Test]
        public void Triangle_With2Sides_ThrowsArgumentException()
        {
            List<double> sides = new List<double> { 5, 2 };

            TestDelegate res = () =>
            {
                Figure triangle = new Figure(FigureType.Triangle, sides);
            };

            Assert.Throws<ArgumentException>(res);
        }

        [Test]
        public void Circle_CheckIfItWorks()
        {
            List<double> sides = new List<double> { 5 };
            Figure circle = new Figure(FigureType.Circle, sides);

            var res = Figure.CalculateArea(circle);

            Assert.That(Math.Round(res, 2) == 78.54);
        }
    }
}