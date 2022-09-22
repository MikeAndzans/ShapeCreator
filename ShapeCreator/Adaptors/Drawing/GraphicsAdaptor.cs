namespace ShapeCreator.Adaptors.Drawing
{
    public class GraphicsAdaptor : IGraphicsAdaptor
    {
        private readonly Graphics _graphics;
        private readonly Pen _pen;

        public GraphicsAdaptor(Graphics graphics, Pen pen)
        {
            _graphics = graphics;
            _pen = pen;
        }

        public void DrawEllipse(int x, int y, int width, int height)
        {
            _graphics.DrawEllipse(_pen, x, y, width, height);
        }

        public void DrawPolygon(Point[] points)
        {
            _graphics.DrawPolygon(_pen, points);
        }

        public void DrawRectangle(int x, int y, int width, int height)
        {
            _graphics.DrawRectangle(_pen, x, y, width, height);
        }

        ~GraphicsAdaptor()
        {
            Dispose();
        }

        public void Dispose()
        {
            _graphics.Dispose();
            _pen.Dispose();
        }
    }
}
