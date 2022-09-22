namespace ShapeCreator.Adaptors
{
    public class ConsoleAdaptor : IConsoleAdaptor
    {
        public void Clear()
        {
            Console.Clear();
        }

        public int Read()
        {
            return Console.Read();
        }

        public string? ReadLine()
        {
            return Console.ReadLine();
        }

        public void SetCursorVisibility(bool visible)
        {
            Console.CursorVisible = visible;
        }

        public void Write(string s)
        {
            Console.Write(s);
        }

        public void WriteLine(string s)
        {
            Console.WriteLine(s);
        }
    }
}
