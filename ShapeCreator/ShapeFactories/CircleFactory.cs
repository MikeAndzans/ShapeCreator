using ShapeCreator.Constants;
using ShapeCreator.Services;
using ShapeCreator.Shapes;

namespace ShapeCreator.ShapeFactories
{
    public class CircleFactory : IShapeFactory<Circle>
    {
        private readonly IConsoleInputService _consoleInputService;

        public CircleFactory(IConsoleInputService consoleInputService)
        {
            _consoleInputService = consoleInputService;
        }

        public Circle CreateShape()
        {
            var radius = _consoleInputService.GetNumericInput(StringConsts.GetCircleRadius);

            return new Circle(radius);
        }
    }
}
