using System;
using Vintagestory.API.Common;

namespace HelveHammerExtensions
{
    public class Core : ModSystem
    {
        public static string ModId { get; private set; }
        public static ILogger ModLogger { get; private set; }

        private ICoreAPI _api;

        public override void StartPre(ICoreAPI api)
        {
            ModLogger = Mod.Logger;
        }

        public override void Start(ICoreAPI api)
        {
            _api = api;
            Config.Current = api.LoadOrCreateConfig<Config>(Mod.Info.ModID + ".json");
        }

        public override void Dispose()
        {
            try
            {
                _api.StoreModConfig(Config.Current, Mod.Info.ModID + ".json");
            }
            catch (Exception e)
            {
                Mod.Logger.Error(e.ToString());
            }
        }
    }
}