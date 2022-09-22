using ShapeCreator.Adaptors;
using ShapeCreator.Constants;
using ShapeCreator.Enums;
using ShapeCreator.Exceptions;
using ShapeCreator.ShapeFactories;
using ShapeCreator.Shapes;
using Rectangle = ShapeCreator.Shapes.Rectangle;

namespace ShapeCreator.Services
{
    public class MainService : IMainService
    {
        private readonly IShapeFactory<Circle> _circleFactory;
        private readonly IShapeFactory<Square> _squareFactory;
        private readonly IShapeFactory<Rectangle> _rectangleFactory;
        private readonly IShapeFactory<Triangle> _triangleFactory;
        private readonly IShapeOutputService _shapeOutputService;
        private readonly IConsoleInputService _consoleInputService;
        private readonly IConsoleAdaptor _consoleAdaptor;

        public MainService(IShapeFactory<Circle> circleFactory,
            IShapeFactory<Square> squareFactory,
            IShapeFactory<Rectangle> rectangleFactory,
            IShapeFactory<Triangle> triangleFactory,
            IShapeOutputService shapeOutputService,
            IConsoleInputService consoleInputService,
            IConsoleAdaptor consoleAdaptor)
        {
            _circleFactory = circleFactory;
            _squareFactory = squareFactory;
            _rectangleFactory = rectangleFactory;
            _triangleFactory = triangleFactory;
            _shapeOutputService = shapeOutputService;
            _consoleInputService = consoleInputService;
            _consoleAdaptor = consoleAdaptor;
        }

        public OutputType GetOutputType()
        {
            var getOutputTypeMessage = string.Format(StringConsts.GetOutputType,
                    OutputTypeConsts.ConsoleSelectionNum, OutputTypeConsts.ConsoleSelectionName,
                    OutputTypeConsts.FileSelectionNum, OutputTypeConsts.FileSelectionName);

            switch (_consoleInputService.GetStringInput(getOutputTypeMessage))
            {
                case OutputTypeConsts.ConsoleSelectionNum:
                    return OutputType.Console;

                case OutputTypeConsts.FileSelectionNum:
                    return OutputType.File;

                default:
                    {
                        throw new InvalidInputException(StringConsts.UnsupportedActionMessage);
                    }
            }
        }

        public IShape GetShape()
        {
            var getShapeMessage = string.Format(StringConsts.GetShapeType,
                ShapeTypeConsts.CircleSelectionNum, ShapeTypeConsts.CircleName,
                ShapeTypeConsts.SquareSelectionNum, ShapeTypeConsts.SquareName,
                ShapeTypeConsts.RectangleSelectionNum, ShapeTypeConsts.RectangleName,
                ShapeTypeConsts.TriangleSelectionNum, ShapeTypeConsts.TriangleName);

            switch (_consoleInputService.GetStringInput(getShapeMessage))
            {
                case ShapeTypeConsts.CircleSelectionNum:
                    return _circleFactory.CreateShape();

                case ShapeTypeConsts.SquareSelectionNum:
                    return _squareFactory.CreateShape();

                case ShapeTypeConsts.RectangleSelectionNum:
                    return _rectangleFactory.CreateShape();

                case ShapeTypeConsts.TriangleSelectionNum:
                    return _triangleFactory.CreateShape();

                default:
                    {
                        throw new InvalidInputException(StringConsts.UnsupportedActionMessage);
                    }
            }
        }

        public void DrawShape(OutputType outputType, IShape shape)
        {
            switch (outputType)
            {
                case OutputType.Console:
                    _shapeOutputService.OutputShapeToConsole(shape);
                    _consoleAdaptor.Read();
                    break;

                case OutputType.File:
                    _shapeOutputService.OutputShapeToFile(shape);
                    break;
            }
        }
    }
}
