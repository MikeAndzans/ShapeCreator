using ShapeCreator.Constants;
using ShapeCreator.Shapes;

namespace ShapeCreator.Adaptors.Drawing
{
    public class FileDrawingAdaptor : IFileDrawingAdaptor
    {
        public FileDrawingAdaptor() { }

        public void DrawShapeToFile(IShape shape, Point startingPoint, string fileName)
        {
            using var bitmap = new Bitmap(
                ImageConsts.DEFAULT_IMAGE_WIDTH,
                ImageConsts.DEFAULT_IMAGE_HEIGHT,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using var graphicsAdaptor = new GraphicsAdaptor(
                Graphics.FromImage(bitmap),
                new Pen(Color.FromKnownColor(ImageConsts.DEFAULT_PEN_COLOR), ImageConsts.DEFAULT_PEN_WIDTH));

            shape.DrawShape(graphicsAdaptor, startingPoint);
            bitmap.Save(fileName);
        }
    }
}