namespace ShapeCreator.Adaptors
{
    public interface IConsoleAdaptor
    {
        public void Clear();

        public int Read();

        public string? ReadLine();

        public void SetCursorVisibility(bool visible);

        public void Write(string s);

        public void WriteLine(string s);
    }
}
