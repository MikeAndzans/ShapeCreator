using ShapeCreator.Shapes;

namespace ShapeCreator.ShapeFactories
{
    public interface IShapeFactory<T> where T : IShape
    {
        T CreateShape();
    }
}
