using ShapeCreator.Adaptors;
using ShapeCreator.Adaptors.Drawing;
using ShapeCreator.Constants;
using ShapeCreator.Services;
using ShapeCreator.Shapes;
using System.Drawing;

namespace Tests.Services
{
    [TestClass]
    public class ShapeOutputServiceTests
    {
        private readonly IShape TEST_SHAPE = new Circle(50);

        private readonly Mock<IConsoleAdaptor> _consoleAdaptorMock = new Mock<IConsoleAdaptor>();
        private readonly Mock<IConsoleDrawingAdaptor> _consoleDrawingAdaptorMock = new Mock<IConsoleDrawingAdaptor>();
        private readonly Mock<IFileDrawingAdaptor> _fileDrawingAdaptorMock = new Mock<IFileDrawingAdaptor>();

        private IShapeOutputService _shapeOutputService;

        [TestInitialize]
        public void Init()
        {
            _consoleAdaptorMock.Setup(x => x.Clear()).Verifiable();
            _consoleAdaptorMock.Setup(x => x.SetCursorVisibility(It.IsAny<bool>())).Verifiable();

            _consoleDrawingAdaptorMock.Setup(x => x.DrawShapeToConsole(It.IsAny<IShape>(), It.IsAny<Point>()))
                .Verifiable();            
            _fileDrawingAdaptorMock.Setup(x => x.DrawShapeToFile(It.IsAny<IShape>(), It.IsAny<Point>(), It.IsAny<string>()))
                .Verifiable();

            _shapeOutputService = new ShapeOutputService(_consoleAdaptorMock.Object, _consoleDrawingAdaptorMock.Object, _fileDrawingAdaptorMock.Object);
        }

        [TestMethod]
        public void OutputShapeToFile_Should_Call_File_Drawing_Adaptor()
        {
            _shapeOutputService.OutputShapeToFile(TEST_SHAPE);

            var fileName = string.Format(StringConsts.FileName, DateTime.Now.ToString(StringConsts.DateFormatString));
            _fileDrawingAdaptorMock.Verify(x => x.DrawShapeToFile(TEST_SHAPE, ImageConsts.DEFAULT_STARTING_POINT, It.IsRegex(fileName)), Times.Once);
        }

        [TestMethod]
        public void OutputShapeToConsole_Should_Call_Console_Drawing_Adaptor()
        {
            _shapeOutputService.OutputShapeToConsole(TEST_SHAPE);

            _consoleAdaptorMock.Verify(x => x.Clear(), Times.Once);
            _consoleAdaptorMock.Verify(x => x.SetCursorVisibility(false), Times.Once);
            _consoleDrawingAdaptorMock.Verify(x => x.DrawShapeToConsole(TEST_SHAPE, ImageConsts.DEFAULT_STARTING_POINT));
        }
    }
}
