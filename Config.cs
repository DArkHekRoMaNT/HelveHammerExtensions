using CommonLib.Config;

namespace HelveHammerExtensions
{
    [Config("helvehammerext.json")]
    public class Config
    {
        [ConfigItem(typeof(bool), false, Description = "Will this work for any items")]
        public bool AllWorkable { get; set; }

        [ConfigItem(typeof(bool), true, Description = "Default behavior")]
        public bool DefaultWorkable { get; set; }

        [ConfigItem(typeof(int), 3, Description = "Minimum anvil tier (1 - copper, 2 - bronze, 3 - iron, 4 - steel in vanilla)")]
        public int AnvilTier { get; set; }
    }
}
