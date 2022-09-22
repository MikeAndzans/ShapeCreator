using ShapeCreator.Shapes;

namespace ShapeCreator.Adaptors.Drawing
{
    public interface IConsoleDrawingAdaptor
    {
        void DrawShapeToConsole(IShape shape, Point startingPoint);
    }
}
