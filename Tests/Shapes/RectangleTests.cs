using ShapeCreator.Adaptors.Drawing;
using System.Drawing;
using Rectangle = ShapeCreator.Shapes.Rectangle;

namespace Tests.Shapes
{
    [TestClass]
    public class RectangleTests
    {
        private readonly int TEST_WIDTH = 10;
        private readonly int TEST_HEIGHT = 15;

        [TestMethod]
        public void RectangleDrawShape_Should_Call_Draw_Rectangle()
        {
            Mock<IGraphicsAdaptor> graphicsMock = new Mock<IGraphicsAdaptor>();

            graphicsMock.Setup(x => x.DrawRectangle(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()))
                .Verifiable();

            var rectangle = new Rectangle(TEST_WIDTH, TEST_HEIGHT);
            var testStartPoint = new Point(10, 5);

            rectangle.DrawShape(graphicsMock.Object, testStartPoint);

            graphicsMock.Verify(x => x.DrawRectangle(testStartPoint.X, testStartPoint.Y, TEST_WIDTH, TEST_HEIGHT), Times.Once());
        }
    }
}
