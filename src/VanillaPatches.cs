using Vintagestory.API.Common;
using HarmonyLib;
using System.Text;

namespace HelveHammerExtensions
{
    class VanillaPatches : ModSystem
    {
        public const string patchCode = "DArkHekRoMaNT.ModSystem.VanillaPatches";
        public Harmony harmonyInstance = new Harmony(patchCode);

        public override void Start(ICoreAPI api)
        {
            harmonyInstance.PatchAll();
            StringBuilder builder = new StringBuilder("Harmony Patched Methods: ");
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