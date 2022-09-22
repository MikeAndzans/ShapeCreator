using ShapeCreator.Constants;
using ShapeCreator.Services;
using ShapeCreator.ShapeFactories;
using ShapeCreator.Shapes;
using System.Drawing;

namespace Tests.ShapeFactories
{
    [TestClass]
    public class TriangleFactoryTests
    {
        private readonly Point TEST_VERTICE_A = new Point(10, 10);
        private readonly Point TEST_VERTICE_B = new Point(30, 30);
        private readonly Point TEST_VERTICE_C = new Point(15, 15);

        private Mock<IConsoleInputService> _consoleInputServiceMock = new Mock<IConsoleInputService>();
        private IShapeFactory<Triangle> _triangleFactory;

        [TestInitialize]
        public void Init()
        {
            _consoleInputServiceMock
                .Setup(x => x.GetNumericInput(It.Is<string>(s => s == string.Format(StringConsts.GetTriangleVerticeXPosition, "A"))))
                .Returns(TEST_VERTICE_A.X);

            _consoleInputServiceMock
                .Setup(x => x.GetNumericInput(It.Is<string>(s => s == string.Format(StringConsts.GetTriangleVerticeYPosition, "A"))))
                .Returns(TEST_VERTICE_A.Y);

            _consoleInputServiceMock
                .Setup(x => x.GetNumericInput(It.Is<string>(s => s == string.Format(StringConsts.GetTriangleVerticeXPosition, "B"))))
                .Returns(TEST_VERTICE_B.X);

            _consoleInputServiceMock
                .Setup(x => x.GetNumericInput(It.Is<string>(s => s == string.Format(StringConsts.GetTriangleVerticeYPosition, "B"))))
                .Returns(TEST_VERTICE_B.Y);

            _consoleInputServiceMock
                .Setup(x => x.GetNumericInput(It.Is<string>(s => s == string.Format(StringConsts.GetTriangleVerticeXPosition, "C"))))
                .Returns(TEST_VERTICE_C.X);

            _consoleInputServiceMock
                .Setup(x => x.GetNumericInput(It.Is<string>(s => s == string.Format(StringConsts.GetTriangleVerticeYPosition, "C"))))
                .Returns(TEST_VERTICE_C.Y);

            _triangleFactory = new TriangleFactory(_consoleInputServiceMock.Object);
        }

        [TestMethod]
        public void CreateShape_Should_Return_Triangle_With_Provided_Vertices()
        {
            var triangle = _triangleFactory.CreateShape();

            triangle.ShouldBeOfType<Triangle>();
            triangle.Vertcies.Length.ShouldBe(3);
            triangle.Vertcies[0].ShouldBeEquivalentTo(TEST_VERTICE_A);
            triangle.Vertcies[1].ShouldBeEquivalentTo(TEST_VERTICE_B);
            triangle.Vertcies[2].ShouldBeEquivalentTo(TEST_VERTICE_C);

            _consoleInputServiceMock.Verify(x => x.GetNumericInput(string.Format(StringConsts.GetTriangleVerticeXPosition, "A")), Times.Once);
            _consoleInputServiceMock.Verify(x => x.GetNumericInput(string.Format(StringConsts.GetTriangleVerticeYPosition, "A")), Times.Once);
            _consoleInputServiceMock.Verify(x => x.GetNumericInput(string.Format(StringConsts.GetTriangleVerticeXPosition, "B")), Times.Once);
            _consoleInputServiceMock.Verify(x => x.GetNumericInput(string.Format(StringConsts.GetTriangleVerticeYPosition, "B")), Times.Once);
            _consoleInputServiceMock.Verify(x => x.GetNumericInput(string.Format(StringConsts.GetTriangleVerticeXPosition, "C")), Times.Once);
            _consoleInputServiceMock.Verify(x => x.GetNumericInput(string.Format(StringConsts.GetTriangleVerticeYPosition, "C")), Times.Once);
        }
    }
}
