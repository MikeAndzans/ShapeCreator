using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeCreator.Adaptors;
using ShapeCreator.Constants;
using ShapeCreator.Enums;
using ShapeCreator.Exceptions;
using ShapeCreator.Services;
using ShapeCreator.Shapes;

namespace Tests.Services
{
    [TestClass]
    public class ExecutorServiceTests
    {
        private readonly OutputType TEST_OUTPUT_TYPE = OutputType.Console;
        private readonly IShape TEST_SHAPE = new Circle(30);

        private readonly Mock<IMainService> _mainServiceMock = new Mock<IMainService>();
        private readonly Mock<IConsoleAdaptor> _consoleAdaptor = new Mock<IConsoleAdaptor>();

        [TestInitialize]
        public void Init()
        {
            _mainServiceMock.Setup(x => x.GetOutputType())
                .Returns(TEST_OUTPUT_TYPE);

            _mainServiceMock.Setup(x => x.DrawShape(It.IsAny<OutputType>(), It.IsAny<IShape>()))
                .Verifiable();

            _consoleAdaptor.Setup(x => x.WriteLine(It.IsAny<string>()))
                .Verifiable();
        }

        [TestMethod]
        public void Start_Should_Call_MainService_Methods()
        {
            _mainServiceMock.Setup(x => x.GetShape())
                .Returns(TEST_SHAPE);

            var executor = new ExecutorService(_mainServiceMock.Object, _consoleAdaptor.Object);

            executor.Start();
            _mainServiceMock.Verify(x => x.GetOutputType(), Times.Once);
            _mainServiceMock.Verify(x => x.GetShape(), Times.Once);
            _mainServiceMock.Verify(x => x.DrawShape(TEST_OUTPUT_TYPE, TEST_SHAPE), Times.Once);
        }

        [TestMethod]
        public void Start_Exception_During_Execution_Should_Ouput_Ex_Message_To_Console()
        {
            _mainServiceMock.Setup(x => x.GetShape())
                .Throws<InvalidInputException>();

            var executor = new ExecutorService(_mainServiceMock.Object, _consoleAdaptor.Object);

            executor.Start();
            _mainServiceMock.Verify(x => x.GetOutputType(), Times.Once);
            _mainServiceMock.Verify(x => x.GetShape(), Times.Once);
            _mainServiceMock.Verify(x => x.DrawShape(It.IsAny<OutputType>(), It.IsAny<IShape>()), Times.Never);
            _consoleAdaptor.Verify(x => x.WriteLine(StringConsts.DefaultInvalidInput), Times.Once);
        }
    }
}
