using HarmonyLib;
using Vintagestory.GameContent;

namespace HelveHammerExtensions
{
    [HarmonyPatch(typeof(ItemWorkItem))]
    [HarmonyPatch("GetHelveWorkableMode")]
    public class GetHelveWorkableModePatch
    {
        public static bool Prefix(ref EnumHelveWorkableMode __result, ref BlockEntityAnvil beAnvil)
        {
            bool workable = Core.Config.DefaultWorkable;
            var attr = beAnvil.SelectedRecipe.Output.Attributes;
            if (attr != null)
            {
                workable = attr["helvehammerworkable"].AsBool();
            }

            if ((workable || Core.Config.AllWorkable) && beAnvil.OwnMetalTier >= Core.Config.AnvilTier)
            {
                __result = EnumHelveWorkableMode.TestSufficientVoxelsWorkable;
                return false;
            }

            return true;
        }
    }
}
