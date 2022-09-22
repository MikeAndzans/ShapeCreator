using ShapeCreator.Constants;
using ShapeCreator.Services;
using Rectangle = ShapeCreator.Shapes.Rectangle;

namespace ShapeCreator.ShapeFactories
{
    public class RectangleFactory : IShapeFactory<Rectangle>
    {
        private readonly IConsoleInputService _consoleInputService;

        public RectangleFactory(IConsoleInputService consoleInputService)
        {
            _consoleInputService = consoleInputService;
        }

        public Rectangle CreateShape()
        {
            var width = _consoleInputService.GetNumericInput(StringConsts.GetRectangleWidth);
            var height = _consoleInputService.GetNumericInput(StringConsts.GetRectangleHeight);

            return new Rectangle(width, height);
        }
    }
}
