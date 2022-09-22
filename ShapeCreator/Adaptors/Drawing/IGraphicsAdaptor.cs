namespace ShapeCreator.Adaptors.Drawing
{
    public interface IGraphicsAdaptor : IDisposable
    {
        void DrawEllipse(int x, int y, int width, int height);

        void DrawRectangle(int x, int y, int width, int height);

        void DrawPolygon(Point[] points);
    }
}
