using CG.GameLoopStateMachine.GameStates;
using HarmonyLib;

namespace LoadingScreenSkip
{
    [HarmonyPatch(typeof(GSIntro), "OnEnter")]
    internal class GSIntroPatch
    {
        //Skips the first game loading screen
        static void Postfix(ref float ____timer)
        {
            ____timer = 0;
        }
    }
}
