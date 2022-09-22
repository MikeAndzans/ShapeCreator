using ShapeCreator.Constants;
using ShapeCreator.Services;
using ShapeCreator.Shapes;

namespace ShapeCreator.ShapeFactories
{
    public class SquareFactory : IShapeFactory<Square>
    {
        private readonly IConsoleInputService _consoleInputService;

        public SquareFactory(IConsoleInputService consoleInputService)
        {
            _consoleInputService = consoleInputService;
        }

        public Square CreateShape()
        {
            var sideLenght = _consoleInputService.GetNumericInput(StringConsts.GetSquareSideLength);

            return new Square(sideLenght);
        }
    }
}
