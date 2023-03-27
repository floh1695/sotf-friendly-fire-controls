using BepInEx;

namespace FriendlyFireControls
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo($"Plugin {PluginString()} is loaded!");
        }

        private void Update()
        {
            Logger.LogInfo($"Plugin {PluginString()} is running!");
        }

        private string PluginString() => $"{PluginInfo.PLUGIN_GUID}-{PluginInfo.PLUGIN_NAME}-{PluginInfo.PLUGIN_VERSION}";
    }
}
