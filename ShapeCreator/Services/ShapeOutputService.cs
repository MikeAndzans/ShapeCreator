using ShapeCreator.Adaptors;
using ShapeCreator.Adaptors.Drawing;
using ShapeCreator.Constants;
using ShapeCreator.Shapes;

namespace ShapeCreator.Services
{
    public class ShapeOutputService : IShapeOutputService
    {
        private readonly IConsoleAdaptor _consoleAdaptor;
        private readonly IConsoleDrawingAdaptor _consoleDrawingAdaptor;
        private readonly IFileDrawingAdaptor _fileDrawingAdaptor;

        public ShapeOutputService(IConsoleAdaptor consoleAdaptor,
            IConsoleDrawingAdaptor consoleDrawingAdaptor,
            IFileDrawingAdaptor fileDrawingAdaptor)
        {
            _consoleAdaptor = consoleAdaptor;
            _consoleDrawingAdaptor = consoleDrawingAdaptor;
            _fileDrawingAdaptor = fileDrawingAdaptor;
        }

        public void OutputShapeToFile(IShape shape)
        {
            var fileName = string.Format(StringConsts.FileName, DateTime.Now.ToString(StringConsts.DateFormatString));
            _fileDrawingAdaptor.DrawShapeToFile(shape, ImageConsts.DEFAULT_STARTING_POINT, fileName);
        }

        public void OutputShapeToConsole(IShape shape)
        {
            _consoleAdaptor.Clear();
            _consoleAdaptor.SetCursorVisibility(false);
            _consoleDrawingAdaptor.DrawShapeToConsole(shape, ImageConsts.DEFAULT_STARTING_POINT);
        }
    }
}
