using System;
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
            try
            {
                api.StoreModConfig(Config.Current, ConstantsCore.ModId + ".json");
            }
            catch (Exception e)
            {
                api.Logger.ModError(e.ToString());
            }
        }
    }
}