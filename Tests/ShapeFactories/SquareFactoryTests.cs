using ShapeCreator.Constants;
using ShapeCreator.Services;
using ShapeCreator.ShapeFactories;
using ShapeCreator.Shapes;

namespace Tests.ShapeFactories
{
    public class SquareFactoryTests
    {
        private const int TEST_SIDE_LENGTH = 50;

        private Mock<IConsoleInputService> _consoleInputServiceMock = new Mock<IConsoleInputService>();
        private IShapeFactory<Square> _squareFactory;

        [TestInitialize]
        public void Init()
        {
            _consoleInputServiceMock
                .Setup(x => x.GetNumericInput(It.Is<string>(s => s == StringConsts.GetSquareSideLength)))
                .Returns(TEST_SIDE_LENGTH);

            _squareFactory = new SquareFactory(_consoleInputServiceMock.Object);
        }

        [TestMethod]
        public void CreateShape_Should_Return_Square_With_Provided_Side_Length()
        {
            var square = _squareFactory.CreateShape();

            square.ShouldBeOfType<Square>();
            square.Widht.ShouldBe(TEST_SIDE_LENGTH);
            square.Height.ShouldBe(TEST_SIDE_LENGTH);
            _consoleInputServiceMock.Verify(x => x.GetNumericInput(StringConsts.GetSquareSideLength), Times.Once);
        }
    }
}
