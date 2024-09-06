using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using System.Reflection;

namespace LoadingScreenSkip
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.USERS_PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    [BepInProcess("Void Crew.exe")]
    [BepInDependency(VoidManager.MyPluginInfo.PLUGIN_GUID)]
    public class BepinPlugin : BaseUnityPlugin
    {
        public static BepinPlugin Instance { get; private set; }
        internal static ManualLogSource Log;

        private void Awake()
        {
            Log = Logger;
            Instance = this;
            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly(), MyPluginInfo.PLUGIN_GUID);
            Logger.LogInfo($"{MyPluginInfo.PLUGIN_NAME} loaded");
        }
    }
}