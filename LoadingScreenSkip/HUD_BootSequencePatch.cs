using CG.Client.Player.HUD;
using CG.Game.Player;
using CG.Ship.Object;
using HarmonyLib;
using System.Reflection;
using UnityEngine.Events;

namespace LoadingScreenSkip
{
    [HarmonyPatch(typeof(HUD_BootSequence), "OnLifeformStateChanged")]
    internal class HUD_BootSequencePatch
    {
        private static readonly MethodInfo bootSequenceComplete = AccessTools.Method(typeof(HUD_BootSequence), "OnBootSequenceComplete");

        //Skips sacograph loading screen
        static bool Prefix(HUD_BootSequence __instance, ILifeform lifeform, UnityEvent ___OnAlive, ref bool ____isFirstTime, ref float ___backgroundFadeDelay)
        {
            if (lifeform != LocalPlayer.Instance) return true; //Continue to method

            if (____isFirstTime)
            {
                ___OnAlive.Invoke();
                ____isFirstTime = false;
                ___backgroundFadeDelay = 0;
                bootSequenceComplete.Invoke(__instance, new object[0]); //See CursorUtilityPatch for bug fix
                return false; //Do not run method
            }

            return true; //Continue to method
        }

        public static void Nop() { }
    }
}
