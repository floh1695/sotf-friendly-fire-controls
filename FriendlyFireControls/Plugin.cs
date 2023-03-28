using BepInEx;
using UnityEngine;

namespace FriendlyFireControls
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    [BepInProcess("SonsOfTheForest.exe")]
    public class Plugin : BaseUnityPlugin
    {
        public double logHeartbeatCounter;

        public void Awake()
        {
            Logger.LogInfo($"Plugin {PluginString()} is loaded!");
        }

        public void Update()
        {
            logHeartbeatCounter += Time.deltaTime;
            if (logHeartbeatCounter > 1.0f)
            {
                logHeartbeatCounter -= 1.0f;
                Logger.LogInfo($"Plugin {PluginString()} is running!");
            }
        }

        private string PluginString() => $"{PluginInfo.PLUGIN_GUID}-{PluginInfo.PLUGIN_NAME}-{PluginInfo.PLUGIN_VERSION}";
    }
}
