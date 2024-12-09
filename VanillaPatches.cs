using Vintagestory.API.Common;
using HarmonyLib;
using System.Text;

namespace HelveHammerExtensions
{
    public class VanillaPatches : ModSystem
    {
        public const string patchCode = "DArkHekRoMaNT.HelveHammerExtensions.VanillaPatches";
        public Harmony harmonyInstance = new(patchCode);

        public override void Start(ICoreAPI api)
        {
            harmonyInstance.PatchAll();
            var builder = new StringBuilder("Harmony Patched Methods: ");
            foreach (var val in harmonyInstance.GetPatchedMethods())
            {
                builder.Append(val.Name + ", ");
            }
            Mod.Logger.Notification(builder.ToString());
        }

        public override void Dispose()
        {
            harmonyInstance.UnpatchAll(patchCode);
        }
    }
}
