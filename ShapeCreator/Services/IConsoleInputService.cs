namespace ShapeCreator.Services
{
    public interface IConsoleInputService
    {
        int GetNumericInput(string message);

        string GetStringInput(string message);
    }
}
