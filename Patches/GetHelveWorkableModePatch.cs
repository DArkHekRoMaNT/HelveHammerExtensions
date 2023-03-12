using HarmonyLib;
using Vintagestory.GameContent;

namespace HelveHammerExtensions
{
    [HarmonyPatch(typeof(ItemWorkItem))]
    [HarmonyPatch("GetHelveWorkableMode")]
    public class GetHelveWorkableModePatch
    {
        public static bool Prefix(ItemWorkItem __instance, ref EnumHelveWorkableMode __result, ref BlockEntityAnvil beAnvil)
        {
            bool workable = Config.Current.DefaultWorkable;
            var attr = beAnvil.SelectedRecipe.Output.Attributes;
            if (attr != null)
            {
                workable = attr["helvehammerworkable"].AsBool();
            }

            if ((workable || Config.Current.AllWorkable) && beAnvil.OwnMetalTier >= Config.Current.AnvilTier)
            {
                __result = EnumHelveWorkableMode.TestSufficientVoxelsWorkable;
                return false;
            }

            return true;
        }
    }
}