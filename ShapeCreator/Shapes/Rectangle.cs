using ShapeCreator.Adaptors.Drawing;

namespace ShapeCreator.Shapes
{
    public class Rectangle : IShape
    {
        public Rectangle(int widht, int height)
        {
            Widht = widht;
            Height = height;
        }

        public int Widht { get; }

        public int Height { get; }

        public void DrawShape(IGraphicsAdaptor graphics, Point startPoint)
        {
            graphics.DrawRectangle(startPoint.X, startPoint.Y, Widht, Height);
        }
    }
}
