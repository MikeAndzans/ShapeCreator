using ShapeCreator.Adaptors;
using ShapeCreator.Constants;
using ShapeCreator.Enums;
using ShapeCreator.Exceptions;
using ShapeCreator.Services;
using ShapeCreator.ShapeFactories;
using ShapeCreator.Shapes;
using System.Drawing;
using Rectangle = ShapeCreator.Shapes.Rectangle;

namespace Tests.Services
{
    [TestClass]
    public class MainServiceTests
    {
        private readonly Circle TEST_CIRCLE = new Circle(30);
        private readonly Rectangle TEST_RECTANGLE = new Rectangle(20, 20);
        private readonly Square TEST_SQUARE = new Square(50);
        private readonly Triangle TEST_TRIANGLE = new Triangle(
            new Point[3]
            {
                new Point(20, 20),
                new Point(30, 40),
                new Point(25, 35)
            });

        private readonly string TEST_GET_OUTPUT_TYPE_MESSAGE = string.Format(StringConsts.GetOutputType,
                    OutputTypeConsts.ConsoleSelectionNum, OutputTypeConsts.ConsoleSelectionName,
                    OutputTypeConsts.FileSelectionNum, OutputTypeConsts.FileSelectionName);

        private readonly string TEST_GET_SHAPE_MESSAGE = string.Format(StringConsts.GetShapeType,
                ShapeTypeConsts.CircleSelectionNum, ShapeTypeConsts.CircleName,
                ShapeTypeConsts.SquareSelectionNum, ShapeTypeConsts.SquareName,
                ShapeTypeConsts.RectangleSelectionNum, ShapeTypeConsts.RectangleName,
                ShapeTypeConsts.TriangleSelectionNum, ShapeTypeConsts.TriangleName);

        private readonly Mock<IShapeFactory<Circle>> _circleFactoryMock = new Mock<IShapeFactory<Circle>>();
        private readonly Mock<IShapeFactory<Square>> _squareFactoryMock = new Mock<IShapeFactory<Square>>();
        private readonly Mock<IShapeFactory<Rectangle>> _rectangleFactoryMock = new Mock<IShapeFactory<Rectangle>>();
        private readonly Mock<IShapeFactory<Triangle>> _triangleFactoryMock = new Mock<IShapeFactory<Triangle>>();
        private readonly Mock<IShapeOutputService> _shapeOutputServiceMock = new Mock<IShapeOutputService>();
        private readonly Mock<IConsoleInputService> _consoleInputServiceMock = new Mock<IConsoleInputService>();
        private readonly Mock<IConsoleAdaptor> _consoleAdaptorMock = new Mock<IConsoleAdaptor>();

        [TestInitialize]
        public void Init()
        {
            _circleFactoryMock.Setup(x => x.CreateShape())
                .Returns(TEST_CIRCLE);

            _squareFactoryMock.Setup(x => x.CreateShape())
                .Returns(TEST_SQUARE);

            _rectangleFactoryMock.Setup(x => x.CreateShape())
                .Returns(TEST_RECTANGLE);

            _triangleFactoryMock.Setup(x => x.CreateShape())
                .Returns(TEST_TRIANGLE);

            _shapeOutputServiceMock.Setup(x => x.OutputShapeToConsole(It.IsAny<IShape>()))
                .Verifiable();

            _shapeOutputServiceMock.Setup(x => x.OutputShapeToFile(It.IsAny<IShape>()))
                .Verifiable();

            _consoleAdaptorMock.Setup(x => x.Read())
                .Returns(1);
        }

        private MainService CreateMainService()
        {
            return new MainService(_circleFactoryMock.Object,
                _squareFactoryMock.Object,
                _rectangleFactoryMock.Object,
                _triangleFactoryMock.Object,
                _shapeOutputServiceMock.Object,
                _consoleInputServiceMock.Object,
                _consoleAdaptorMock.Object);
        }

        private void SetupConsoleInputServiceMockWithGetStringInputMethod(string returns)
        {
            _consoleInputServiceMock.Setup(x => x.GetStringInput(It.IsAny<string>()))
                .Returns(returns);
        }

        [TestMethod]
        public void GetOutputType_Console_Type_Input_Should_Return_Console_Type()
        {
            SetupConsoleInputServiceMockWithGetStringInputMethod(OutputTypeConsts.ConsoleSelectionNum);

            var mainService = CreateMainService();
            var outputType = mainService.GetOutputType();

            outputType.ShouldBe(OutputType.Console);
            _consoleInputServiceMock.Verify(x => x.GetStringInput(TEST_GET_OUTPUT_TYPE_MESSAGE), Times.Once);
        }

        [TestMethod]
        public void GetOutputType_File_Type_Input_Should_Return_File_Type()
        {
            SetupConsoleInputServiceMockWithGetStringInputMethod(OutputTypeConsts.FileSelectionNum);

            var mainService = CreateMainService();
            var outputType = mainService.GetOutputType();

            outputType.ShouldBe(OutputType.File);
            _consoleInputServiceMock.Verify(x => x.GetStringInput(TEST_GET_OUTPUT_TYPE_MESSAGE), Times.Once);
        }

        [TestMethod]
        public void GetOutputType_Unknown_Type_Input_Should_Throw_Exception()
        {
            SetupConsoleInputServiceMockWithGetStringInputMethod("abs");

            var mainService = CreateMainService();

            Should.Throw<InvalidInputException>(() => mainService.GetOutputType()).Message.ShouldBe(StringConsts.UnsupportedActionMessage);
            _consoleInputServiceMock.Verify(x => x.GetStringInput(TEST_GET_OUTPUT_TYPE_MESSAGE), Times.Once);
        }


        [TestMethod]
        public void GetShape_Circle_Should_Return_Circle()
        {
            SetupConsoleInputServiceMockWithGetStringInputMethod(ShapeTypeConsts.CircleSelectionNum);

            var mainService = CreateMainService();
            var outShape = mainService.GetShape();

            outShape.ShouldBeSameAs(TEST_CIRCLE);
            _consoleInputServiceMock.Verify(x => x.GetStringInput(TEST_GET_SHAPE_MESSAGE), Times.Once);
        }

        [TestMethod]
        public void GetShape_Square_Should_Return_Square()
        {
            SetupConsoleInputServiceMockWithGetStringInputMethod(ShapeTypeConsts.SquareSelectionNum);

            var mainService = CreateMainService();
            var outShape = mainService.GetShape();

            outShape.ShouldBeSameAs(TEST_SQUARE);
            _consoleInputServiceMock.Verify(x => x.GetStringInput(TEST_GET_SHAPE_MESSAGE), Times.Once);
        }

        [TestMethod]
        public void GetShape_Rectangle_Should_Return_Rectangle()
        {
            SetupConsoleInputServiceMockWithGetStringInputMethod(ShapeTypeConsts.RectangleSelectionNum);

            var mainService = CreateMainService();
            var outShape = mainService.GetShape();

            outShape.ShouldBeSameAs(TEST_RECTANGLE);
            _consoleInputServiceMock.Verify(x => x.GetStringInput(TEST_GET_SHAPE_MESSAGE), Times.Once);
        }

        [TestMethod]
        public void GetShape_Triangle_Should_Return_Triangle()
        {
            SetupConsoleInputServiceMockWithGetStringInputMethod(ShapeTypeConsts.TriangleSelectionNum);

            var mainService = CreateMainService();
            var outShape = mainService.GetShape();

            outShape.ShouldBeSameAs(TEST_TRIANGLE);
            _consoleInputServiceMock.Verify(x => x.GetStringInput(TEST_GET_SHAPE_MESSAGE), Times.Once);
        }

        [TestMethod]
        public void GetShape_Unknown_Should_Throw_Exception()
        {
            SetupConsoleInputServiceMockWithGetStringInputMethod("abc");

            var mainService = CreateMainService();

            Should.Throw<InvalidInputException>(() => mainService.GetShape()).Message.ShouldBe(StringConsts.UnsupportedActionMessage);
            _consoleInputServiceMock.Verify(x => x.GetStringInput(TEST_GET_SHAPE_MESSAGE), Times.Once);
        }


        [TestMethod]
        public void DrawShape_Console_Output_Type_Should_Call_Console_Output()
        {
            var mainService = CreateMainService();
            mainService.DrawShape(OutputType.Console, TEST_SQUARE);

            _shapeOutputServiceMock.Verify(x => x.OutputShapeToConsole(TEST_SQUARE), Times.Once);
            _consoleAdaptorMock.Verify(x => x.Read(), Times.Once);
        }

        [TestMethod]
        public void DrawShape_File_Output_Type_Should_Call_File_Output()
        {
            var mainService = CreateMainService();
            mainService.DrawShape(OutputType.File, TEST_SQUARE);

            _shapeOutputServiceMock.Verify(x => x.OutputShapeToFile(TEST_SQUARE), Times.Once);
            _consoleAdaptorMock.Verify(x => x.Read(), Times.Never);
        }
    }
}
