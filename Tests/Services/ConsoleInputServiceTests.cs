using ShapeCreator.Adaptors;
using ShapeCreator.Constants;
using ShapeCreator.Exceptions;
using ShapeCreator.Services;

namespace Tests.Services
{
    [TestClass]
    public class ConsoleInputServiceTests
    {
        private readonly string TEST_MESSAGE = "Test message";

        private Mock<IConsoleAdaptor> _consoleAdaptorMock = new Mock<IConsoleAdaptor>();

        [TestInitialize]
        public void Init()
        {
            _consoleAdaptorMock.Setup(x => x.Write(It.IsAny<string>()))
                .Verifiable();
        }

        [TestMethod]
        public void GetNumericInput_Should_Return_Parsed_Int_If_Correct()
        {
            var input = "123";
            _consoleAdaptorMock.Setup(x => x.ReadLine())
                .Returns(input);

            var consoleInputService = new ConsoleInputService(_consoleAdaptorMock.Object);

            consoleInputService.GetNumericInput(TEST_MESSAGE).ShouldBe(123);
            _consoleAdaptorMock.Verify(x => x.Write(TEST_MESSAGE), Times.Once);
            _consoleAdaptorMock.Verify(x => x.ReadLine(), Times.Once);
        }

        [TestMethod]
        public void GetNumericInput_Should_Throw_Exception_If_Not_Numeris()
        {
            var input = "123asd";
            _consoleAdaptorMock.Setup(x => x.ReadLine())
                .Returns(input);

            var consoleInputService = new ConsoleInputService(_consoleAdaptorMock.Object);

            Should.Throw<InvalidInputException>(() => consoleInputService.GetNumericInput(TEST_MESSAGE)).Message.ShouldBe(StringConsts.InvalidNumericInput);
            _consoleAdaptorMock.Verify(x => x.Write(TEST_MESSAGE), Times.Once);
        }

        [TestMethod]
        public void GetStringInput_Should_Return_Raw_String()
        {
            var input = "123dsf";
            _consoleAdaptorMock.Setup(x => x.ReadLine())
                .Returns(input);

            var consoleInputService = new ConsoleInputService(_consoleAdaptorMock.Object);

            consoleInputService.GetStringInput(TEST_MESSAGE).ShouldBe(input);
            _consoleAdaptorMock.Verify(x => x.Write(TEST_MESSAGE), Times.Once);
            _consoleAdaptorMock.Verify(x => x.ReadLine(), Times.Once);
        }
    }
}
