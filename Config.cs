namespace HelveHammerExtensions
{
    public class Config
    {
        public static Config Current { get; set; }
        public bool AllWorkable { get; set; }
        public bool DefaultWorkable { get; set; }
        public int AnvilTier { get; set; }

        public Config()
        {
            AllWorkable = false;
            DefaultWorkable = true;
            AnvilTier = 3;
        }

        static Config()
        {
            Current = new Config();
        }
    }
}