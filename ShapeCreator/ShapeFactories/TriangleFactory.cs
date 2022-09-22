using ShapeCreator.Constants;
using ShapeCreator.Services;
using ShapeCreator.Shapes;

namespace ShapeCreator.ShapeFactories
{
    public class TriangleFactory : IShapeFactory<Triangle>
    {
        private readonly Dictionary<int, string> verticeNames = new Dictionary<int, string>
        {
            { 1, "A" },
            { 2, "B" },
            { 3, "C" }
        };

        private readonly IConsoleInputService _consoleInputService;

        public TriangleFactory(IConsoleInputService consoleInputService)
        {
            _consoleInputService = consoleInputService;
        }

        public Triangle CreateShape()
        {
            var vertices = new Point[3];

            for (int i = 0; i < 3; i++)
            {
                vertices[i] = CreateVerticePoint(verticeNames[i + 1]);
            }

            return new Triangle(vertices);
        }

        private Point CreateVerticePoint(string verticeName)
        {
            var verticeAX = _consoleInputService.GetNumericInput(string.Format(StringConsts.GetTriangleVerticeXPosition, verticeName));
            var verticeAY = _consoleInputService.GetNumericInput(string.Format(StringConsts.GetTriangleVerticeYPosition, verticeName));

            return new Point(verticeAX, verticeAY);
        }
    }
}
