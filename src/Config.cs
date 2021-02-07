namespace HelveHammerExtensions
{
    public class Config
    {
        public static Config Current { get; set; } = new Config();
        public bool AllWorkable { get; set; } = false;
        public bool DefaultWorkable { get; set; } = true;
        public int AnvilTier { get; set; } = 3;
    }
}