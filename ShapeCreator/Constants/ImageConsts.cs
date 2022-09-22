namespace ShapeCreator.Constants
{
    /// <summary>
    /// While I'm aware of using app.config file for configuration purposes,
    /// but I'm aiming to create "portable", self contained console app,
    /// so I've decided to store configuration in code
    /// </summary>
    public static class ImageConsts
    {
        public const short DEFAULT_IMAGE_WIDTH = 800;

        public const short DEFAULT_IMAGE_HEIGHT = 600;

        public static readonly Point DEFAULT_STARTING_POINT = new(20, 20);

        public const float DEFAULT_PEN_WIDTH = 2f;

        public const KnownColor DEFAULT_PEN_COLOR = KnownColor.Red;
    }
}
