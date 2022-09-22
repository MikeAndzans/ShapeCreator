using ShapeCreator.Enums;
using ShapeCreator.Shapes;

namespace ShapeCreator.Services
{
    public interface IMainService
    {
        OutputType GetOutputType();

        IShape GetShape();

        void DrawShape(OutputType outputType, IShape shape);
    }
}
