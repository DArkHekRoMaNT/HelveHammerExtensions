using HarmonyLib;
using Vintagestory.GameContent;

namespace HelveHammerExtensions
{
    [HarmonyPatch(typeof(ItemWorkItem))]
    [HarmonyPatch(nameof(ItemWorkItem.GetHelveWorkableMode))]
    public class Patch_ItemWorkItem_GetHelveWorkableMode
    {
        public static bool Prefix(ref EnumHelveWorkableMode __result, ref BlockEntityAnvil beAnvil)
        {
            var workable = Core.Config.DefaultWorkable;
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
