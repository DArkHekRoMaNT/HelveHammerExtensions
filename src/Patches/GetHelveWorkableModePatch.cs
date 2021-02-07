using HarmonyLib;
using Vintagestory.GameContent;

namespace HelveHammerExtensions
{

    [HarmonyPatch(typeof(ItemWorkItem))]
    [HarmonyPatch(nameof(ItemWorkItem.GetHelveWorkableMode))]
    public class GetHelveWorkableModePatch
    {
        public static bool Prefix(ItemWorkItem __instance, ref EnumHelveWorkableMode __result, ref BlockEntityAnvil beAnvil)
        {
            bool workable = beAnvil.SelectedRecipe.Output.Attributes?["helvehammerworkable"]?.AsBool() ?? Config.Current.DefaultWorkable;

            if ((workable || Config.Current.AllWorkable) && beAnvil.OwnMetalTier >= Config.Current.AnvilTier)
            {
                __result = EnumHelveWorkableMode.TestSufficientVoxelsWorkable;
                return false;
            }

            return true;
        }
    }
}