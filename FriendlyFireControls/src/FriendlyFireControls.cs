using BepInEx.Logging;
using UnityEngine;

namespace FriendlyFireControls;

public class FriendlyFireControls : MonoBehaviour
{
    private int seconds { get; set; }
    private double logHeartbeatCounter { get; set; }

    void Start()
    {
        Plugin.Log.LogInfo($"Plugin {MyPluginInfoString.Value()} has started!");
    }

    void Update()
    {
        logHeartbeatCounter += Time.deltaTime;

        if (logHeartbeatCounter > 10.0f)
        {
            seconds += 10;
            logHeartbeatCounter -= 10.0f;

            Plugin.Log.LogInfo($"Plugin {MyPluginInfoString.Value()} has been running for {seconds} seconds!");
        }
    }
}
