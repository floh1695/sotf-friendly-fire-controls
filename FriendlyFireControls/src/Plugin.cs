using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using Il2CppInterop.Runtime.Injection;
using System;
using System.Reflection;
using UnityEngine;

namespace FriendlyFireControls;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BasePlugin
{
    internal static new ManualLogSource Log;

    public override void Load()
    {
        Plugin.Log = base.Log;

        TryLoad();
    }

    private void TryLoad()
    {
        try
        {
            Log.LogInfo($"Trying to load plugin: {MyPluginInfoString.Value()}");

            ClassInjector.RegisterTypeInIl2Cpp<FriendlyFireControls>();
            var plugin = new GameObject(typeof(FriendlyFireControls).FullName);
            UnityEngine.Object.DontDestroyOnLoad(plugin);
            plugin.AddComponent<FriendlyFireControls>();
            plugin.hideFlags = HideFlags.HideAndDontSave;

            Log.LogInfo("Plugin has been loaded!");

            TryPatch();
        }
        catch (Exception e)
        {
            Log.LogError("Error loading the plugin!");
            Log.LogError(e);
        }
    }

    private void TryPatch()
    {
        try
        {
            Log.LogInfo($"Attempting to patch...");

            Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());

            Log.LogInfo($"Successfully patched!");
        }
        catch (Exception e)
        {
            Log.LogError($"Error registering patch!");
            Log.LogError(e);
        }
    }
}
