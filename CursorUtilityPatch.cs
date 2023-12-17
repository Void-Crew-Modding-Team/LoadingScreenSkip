using CG.Client.Utils;
using CG.Game.Player;
using HarmonyLib;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine.UIElements;

namespace LoadingScreenSkip
{
    [HarmonyPatch(typeof(CursorUtility), "ShowCursor")]
    internal class CursorUtilityPatch
    {
        private static readonly FieldInfo mainMenuField = AccessTools.Field(typeof(EscapeMenu), "_mainMenu");
        private static readonly FieldInfo respawnButtonField = AccessTools.Field(typeof(MainMenu), "_forceRespawnButton");
        private static readonly FieldInfo cloneTubesField = AccessTools.Field(typeof(SpawnSystem), "clonetubes");

        //Fixes no respawn button caused HUD_BootSequencePatch
        //Side effect: the respawn button is now always available
        static void Postfix(IShowCursorSource source, bool show)
        {
            MenuScreenController controller = source as MenuScreenController;
            if (controller == null || show == false || SpawnSystem.Instance == null) return;
            foreach (CloneTube tube in (List<CloneTube>)cloneTubesField.GetValue(SpawnSystem.Instance))
            {
                if (tube.GetOccupant() == LocalPlayer.Instance) return; //Prevent respawning in sarcograph
            }

            EscapeMenu escapeMenu = controller.FindScreen<EscapeMenu>();
            MainMenu mainMenu = (MainMenu)mainMenuField.GetValue(escapeMenu);
            Button respawnButton = (Button)respawnButtonField.GetValue(mainMenu);
            respawnButton.SetEnabled(true);
        }
    }
}
