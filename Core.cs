using CommonLib.Config;
using Vintagestory.API.Common;

namespace HelveHammerExtensions
{
    public class Core : ModSystem
    {
        public static Config Config { get; private set; } = null!;

        public override void Start(ICoreAPI api)
        {
            var configs = api.ModLoader.GetModSystem<ConfigManager>();
            Config = configs.GetConfig<Config>();
        }
    }
}
