using Vintagestory.API.Common;
using HarmonyLib;
using Vintagestory.API.Server;
using System.Text;

namespace HelveHammerExtensions
{
    class VanillaPatches : ModSystem
    {
        public const string patchCode = "DArkHekRoMaNT.ModSystem.VanillaPatches";
        public Harmony harmonyInstance = new Harmony(patchCode);

        public override void StartServerSide(ICoreServerAPI api)
        {
            harmonyInstance.PatchAll();
            StringBuilder builder = new StringBuilder("Harmony Patched Methods: ");
            foreach (var val in harmonyInstance.GetPatchedMethods())
            {
                builder.Append(val.Name + ", ");
            }
            api.Logger.Notification(builder.ToString());
        }

        public override void Dispose()
        {
            harmonyInstance.UnpatchAll(patchCode);
        }
    }
}