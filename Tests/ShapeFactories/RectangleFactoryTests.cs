using ShapeCreator.Constants;
using ShapeCreator.Services;
using ShapeCreator.ShapeFactories;
using ShapeCreator.Shapes;

namespace Tests.ShapeFactories
{
    [TestClass]
    public class RectangleFactoryTests
    {
        private const int TEST_WIDTH = 20;
        private const int TEST_HEIGHT = 40;

        private Mock<IConsoleInputService> _consoleInputServiceMock = new Mock<IConsoleInputService>();
        private IShapeFactory<Rectangle> _rectangleFactory;

        [TestInitialize]
        public void Init()
        {
            _consoleInputServiceMock
                .Setup(x => x.GetNumericInput(It.Is<string>(s => s == StringConsts.GetRectangleWidth)))
                .Returns(TEST_WIDTH);

            _consoleInputServiceMock
                .Setup(x => x.GetNumericInput(It.Is<string>(s => s == StringConsts.GetRectangleHeight)))
                .Returns(TEST_HEIGHT);

            _rectangleFactory = new RectangleFactory(_consoleInputServiceMock.Object);
        }

        [TestMethod]
        public void CreateShape_Should_Return_Rectangle_With_Provided_Lengths()
        {
            var rectangle = _rectangleFactory.CreateShape();

            rectangle.ShouldBeOfType<Rectangle>();
            rectangle.Widht.ShouldBe(TEST_WIDTH);
            rectangle.Height.ShouldBe(TEST_HEIGHT);
            _consoleInputServiceMock.Verify(x => x.GetNumericInput(StringConsts.GetRectangleWidth), Times.Once);
            _consoleInputServiceMock.Verify(x => x.GetNumericInput(StringConsts.GetRectangleHeight), Times.Once);
        }
    }
}
