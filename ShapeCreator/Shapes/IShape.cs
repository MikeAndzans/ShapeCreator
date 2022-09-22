using ShapeCreator.Adaptors.Drawing;

namespace ShapeCreator.Shapes
{
    public interface IShape
    {
        void DrawShape(IGraphicsAdaptor graphics, Point startPoint);
    }
}
