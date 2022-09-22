using ShapeCreator.Shapes;

namespace ShapeCreator.Services
{
    public interface IShapeOutputService
    {
        void OutputShapeToConsole(IShape shape);

        void OutputShapeToFile(IShape shape);
    }
}
