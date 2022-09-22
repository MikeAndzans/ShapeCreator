using ShapeCreator.Shapes;

namespace ShapeCreator.Adaptors.Drawing
{
    public interface IFileDrawingAdaptor
    {
        void DrawShapeToFile(IShape shape, Point startingPoint, string fileName);
    }
}
