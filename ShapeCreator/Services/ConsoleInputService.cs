using ShapeCreator.Adaptors;
using ShapeCreator.Constants;
using ShapeCreator.Exceptions;

namespace ShapeCreator.Services
{
    public class ConsoleInputService : IConsoleInputService
    {
        private readonly IConsoleAdaptor _consoleAdaptor;

        public ConsoleInputService(IConsoleAdaptor consoleAdaptor)
        {
            _consoleAdaptor = consoleAdaptor;
        }

        public int GetNumericInput(string message)
        {
            if (!int.TryParse(GetRawInput(message), out int parsedOutput))
            {
                throw new InvalidInputException(StringConsts.InvalidNumericInput);
            }

            return parsedOutput;
        }

        public string GetStringInput(string message)
        {
            return GetRawInput(message);
        }

        private string GetRawInput(string message)
        {
            _consoleAdaptor.Write(message);

            return _consoleAdaptor.ReadLine()?.Trim() ?? string.Empty;
        }
    }
}
