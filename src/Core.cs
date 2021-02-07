using SharedUtils;
using SharedUtils.Extensions;
using Vintagestory.API.Common;

namespace HelveHammerExtensions
{
    public class Core : ModSystem
    {
        ICoreAPI api;
        public override void Start(ICoreAPI api)
        {
            this.api = api;

            Config.Current = api.LoadOrCreateConfig<Config>(ConstantsCore.ModId + ".json");
        }
        public override void Dispose()
        {
            api.StoreModConfig<Config>(Config.Current, ConstantsCore.ModId + ".json");
        }
    }
}