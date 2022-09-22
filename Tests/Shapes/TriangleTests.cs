using ShapeCreator.Adaptors.Drawing;
using ShapeCreator.Constants;
using ShapeCreator.Shapes;
using System.Drawing;

namespace Tests.Shapes
{
    [TestClass]
    public class TriangleTests
    {
        private readonly Point[] TEST_VERTICES = new Point[]
        {
            new Point(10, 10),
            new Point(20, 20),
            new Point(30, 30),
        };

        [TestMethod]
        public void TrinagleConstructor_Valid_Verticles_Should_Create()
        {
            var triangle = new Triangle(TEST_VERTICES);

            triangle.Vertcies.ShouldBe(TEST_VERTICES);
        }

        [TestMethod]
        public void TrinagleConstructor_Null_Verticles_Array_Should_Throw_Error()
        {
            Point[] vertices = null;

            Should.Throw<InvalidDataException>(() => new Triangle(vertices)).Message.ShouldBe(StringConsts.InvalidVerticesInput);
        }

        [TestMethod]
        public void TrinagleConstructor_Incorrect_Verticles_Array_Size_Should_Throw_Error()
        {
            var vertices = new Point[2];

            Should.Throw<InvalidDataException>(() => new Triangle(vertices)).Message.ShouldBe(StringConsts.InvalidVerticesInput);
        }

        [TestMethod]
        public void TriangleDrawShape_Should_Call_Draw_Polygon_With_Altered_Vertices()
        {
            Mock<IGraphicsAdaptor> graphicsMock = new Mock<IGraphicsAdaptor>();

            graphicsMock.Setup(x => x.DrawPolygon(It.IsAny<Point[]>()))
                .Verifiable();

            var trinagle = new Triangle(TEST_VERTICES);
            var testStartPoint = new Point(15, 5);
            var alteredVertices = TEST_VERTICES
                .Select(tv => new Point(tv.X + testStartPoint.X, tv.Y + testStartPoint.Y))
                .ToArray();

            trinagle.DrawShape(graphicsMock.Object, testStartPoint);

            graphicsMock.Verify(x => x.DrawPolygon(alteredVertices), Times.Once);
        }
    }
}
