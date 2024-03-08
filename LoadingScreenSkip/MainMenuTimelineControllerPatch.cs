using HarmonyLib;

namespace LoadingScreenSkip
{
    [HarmonyPatch(typeof(MainMenuTimelineController), "Update")]
    internal class MainMenuTimelineControllerPatch
    {
        //Skips the second game loading screen
        static void Prefix(ref bool ____skipIntro)
        {
            ____skipIntro = true;
        }
    }
}
