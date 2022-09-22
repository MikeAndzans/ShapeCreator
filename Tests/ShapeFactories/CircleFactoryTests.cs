using ShapeCreator.Constants;
using ShapeCreator.Services;
using ShapeCreator.ShapeFactories;
using ShapeCreator.Shapes;

namespace Tests.ShapeFactories
{
    [TestClass]
    public class CircleFactoryTests
    {
        private const int TEST_RADIUS = 30;

        private Mock<IConsoleInputService> _consoleInputServiceMock = new Mock<IConsoleInputService>();
        private IShapeFactory<Circle> _circleFactory;

        [TestInitialize]
        public void Init()
        {
            _consoleInputServiceMock
                .Setup(x => x.GetNumericInput(It.Is<string>(s => s == StringConsts.GetCircleRadius)))
                .Returns(TEST_RADIUS);

            _circleFactory = new CircleFactory(_consoleInputServiceMock.Object);
        }
        
        [TestMethod]
        public void CreateShape_Should_Return_Circle_With_Provided_Radius()
        {
            var circle = _circleFactory.CreateShape();

            circle.ShouldBeOfType<Circle>();
            circle.Radius.ShouldBe(TEST_RADIUS);
            _consoleInputServiceMock.Verify(x => x.GetNumericInput(StringConsts.GetCircleRadius), Times.Once);
        }
    }
}
