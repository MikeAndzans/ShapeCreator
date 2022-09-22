using ShapeCreator.Constants;
using ShapeCreator.Adaptors.Drawing;

namespace ShapeCreator.Shapes
{
    public class Triangle : IShape
    {

        public Triangle(Point[] vertices)
        {
            if (vertices == null || vertices.Length != 3)
            {
                throw new InvalidDataException(StringConsts.InvalidVerticesInput);
            }

            Vertcies = vertices;
        }

        public Point[] Vertcies { get; }

        public void DrawShape(IGraphicsAdaptor graphics, Point startPoint)
        {
            // starPoint is used to set image left and right margins,
            // so we are offsetting all triangle vertices by marging amount
            var verticesOffseted = Vertcies
                .Select(v => new Point(v.X + startPoint.X, v.Y + startPoint.Y))
                .ToArray();

            graphics.DrawPolygon(verticesOffseted);
        }
    }
}
