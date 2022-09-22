namespace ShapeCreator.Constants
{
    public static class StringConsts
    {
        // Circle factory
        public const string GetCircleRadius = "Please, enter circle radius in pixels:\n>";

        // Rectangle factory
        public const string GetRectangleWidth = "Please, enter rectangle width in pixels:\n>";
        public const string GetRectangleHeight = "Please, enter rectangle height in pixels:\n>";

        // Square factory
        public const string GetSquareSideLength = "Please, enter square side lenght in pixels:\n>";

        // Triangle factory
        public const string GetTriangleVerticeXPosition = "Please, enter vertice {0} X location in pixels:\n>";
        public const string GetTriangleVerticeYPosition = "Please, enter vertice {0} Y location in pixels:\n>";

        // Main service
        public const string GetOutputType = 
@"Please select output type (by typing output number):
{0}) {1}
{2}) {3}
>";

        public const string GetShapeType =
@"Please select shape for drawing (by typing shape number):
{0}) {1}
{2}) {3}
{4}) {5}
{6}) {7}
>";

        public const string UnsupportedActionMessage = "Unsupported action!";

        // ConsoleInput service
        public const string InvalidNumericInput = "Invalid input, only numeric values accepted!";

        // ShapeOutput service
        public const string FileName = "shape_output_{0}.bmp";
        public const string DateFormatString = "yyyy-MM-dd--HH-mm-ss";

        // Triangle
        public const string InvalidVerticesInput = "Invalid vertices amount (3 vertices are required for triangle)";

        // IvalidInput exception
        public const string DefaultInvalidInput = "Invalid input detected, aborting!";
    }
}
