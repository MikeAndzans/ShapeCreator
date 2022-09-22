using Microsoft.Extensions.DependencyInjection;
using ShapeCreator.Adaptors;
using ShapeCreator.Adaptors.Drawing;
using ShapeCreator.Services;
using ShapeCreator.ShapeFactories;
using ShapeCreator.Shapes;
using Rectangle = ShapeCreator.Shapes.Rectangle;

internal class Program
{
    private static void Main(string[] args)
    {
        var services = new ServiceCollection();

        ConfigureServices(services);

        // Register main executor
        services.AddSingleton<ExecutorService>();

        // Start main process handler
        services
            .BuildServiceProvider()
            .GetService<ExecutorService>()
            .Start();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services
            .AddSingleton<IConsoleInputService, ConsoleInputService>()
            .AddSingleton<IShapeFactory<Circle>, CircleFactory>()
            .AddSingleton<IShapeFactory<Square>, SquareFactory>()
            .AddSingleton<IShapeFactory<Rectangle>, RectangleFactory>()
            .AddSingleton<IShapeFactory<Triangle>, TriangleFactory>()
            .AddSingleton<IShapeOutputService, ShapeOutputService>()
            .AddSingleton<IConsoleAdaptor, ConsoleAdaptor>()
            .AddSingleton<IMainService, MainService>()
            .AddSingleton<IConsoleDrawingAdaptor, ConsoleDrawingAdaptor>()
            .AddSingleton<IFileDrawingAdaptor, FileDrawingAdaptor>();
    }
}