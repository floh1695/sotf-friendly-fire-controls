using BepInEx;
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
    public override void Load()
    {
        TryLoad();
    }

    private void TryLoad()
    {
        try
        {
            Log.LogInfo($"Trying to load plugin...: {MyPluginInfoString.Value()}");

            ClassInjector.RegisterTypeInIl2Cpp<FriendlyFireControls>();
            var plugin = new GameObject(typeof(FriendlyFireControls).FullName);
            UnityEngine.Object.DontDestroyOnLoad(plugin);
            plugin.AddComponent<FriendlyFireControls>();
            var friendlyFireControls = plugin.GetComponent<FriendlyFireControls>();
            friendlyFireControls.Log = Log;

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
