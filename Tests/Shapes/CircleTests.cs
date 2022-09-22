using ShapeCreator.Adaptors.Drawing;
using ShapeCreator.Shapes;
using System.Drawing;

namespace Tests.Shapes
{
    [TestClass]
    public class CircleTests
    {
        private readonly int TEST_RADIUS = 50;

        [TestMethod]
        public void CircleDrawShape_Should_Call_Draw_Ellips()
        {
            Mock<IGraphicsAdaptor> graphicsMock = new Mock<IGraphicsAdaptor>();

            graphicsMock.Setup(x => x.DrawEllipse(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Verifiable();

            var circle = new Circle(TEST_RADIUS);
            var testStartPoint = new Point(10, 5);

            circle.DrawShape(graphicsMock.Object, testStartPoint);

            graphicsMock.Verify(x => x.DrawEllipse(testStartPoint.X, testStartPoint.Y, TEST_RADIUS * 2, TEST_RADIUS * 2), Times.Once());
        }
    }
}
