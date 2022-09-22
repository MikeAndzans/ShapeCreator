using ShapeCreator.Constants;

namespace ShapeCreator.Exceptions
{
    public class InvalidInputException : Exception
    {
        public InvalidInputException() : base(StringConsts.DefaultInvalidInput) { }

        public InvalidInputException(string message) : base(message) { }
    }
}
