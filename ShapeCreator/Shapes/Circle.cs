using ShapeCreator.Adaptors.Drawing;

namespace ShapeCreator.Shapes
{
    public class Circle : IShape
    {
        public Circle(int radius)
        {
            Radius = radius;
        }

        public int Radius { get; }

        public void DrawShape(IGraphicsAdaptor graphics, Point startPoint)
        {
            var diameter = Radius * 2;

            graphics.DrawEllipse(startPoint.X, startPoint.Y, diameter, diameter);
        }
    }
}
