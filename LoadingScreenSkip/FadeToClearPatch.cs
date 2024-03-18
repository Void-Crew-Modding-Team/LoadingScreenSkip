using CG.Client.UI;
using HarmonyLib;

namespace LoadingScreenSkip
{
    [HarmonyPatch(typeof(FadeController), "FadeToClear")]
    class FadeToClearPatch
    {
        [HarmonyPrefix]
        static void DurationReplacement(ref float duration)
        {
            duration = 0f;
        }
    }
    [HarmonyPatch(typeof(FadeController), "FadeToClearDelayed")]
    class FadeToClearDelayedPatch
    {
        [HarmonyPrefix]
        static void DurationReplacement(ref float delay, ref float duration)
        {
            delay = 0f;
            duration = 0f;
        }
    }
}
