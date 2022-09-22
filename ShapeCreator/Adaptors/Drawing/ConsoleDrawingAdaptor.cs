using ShapeCreator.Constants;
using ShapeCreator.Shapes;
using System.Runtime.InteropServices;

namespace ShapeCreator.Adaptors.Drawing
{
    public class ConsoleDrawingAdaptor : IConsoleDrawingAdaptor
    {
        [DllImport("kernel32.dll", EntryPoint = "GetConsoleWindow", SetLastError = true)]
        private static extern IntPtr GetConsoleHandle();

        public ConsoleDrawingAdaptor() { }

        public void DrawShapeToConsole(IShape shape, Point startingPoint)
        {
            var consoleHandle = GetConsoleHandle();
            using var graphicsAdaptor = new GraphicsAdaptor(Graphics.FromHwnd(consoleHandle),
                new Pen(Color.FromKnownColor(ImageConsts.DEFAULT_PEN_COLOR), ImageConsts.DEFAULT_PEN_WIDTH));

            shape.DrawShape(graphicsAdaptor, startingPoint);
        }
    }
}
