using BepInEx.Logging;
using UnityEngine;

namespace FriendlyFireControls;

public class FriendlyFireControls : MonoBehaviour
{
    public ManualLogSource Log { get; set; }

    private int seconds { get; set; }
    private double logHeartbeatCounter { get; set; }

    public void Start()
    {
        Log.LogInfo($"Plugin {MyPluginInfoString.Value()} has started!");
    }

    public void Update()
    {
        logHeartbeatCounter += Time.deltaTime;

        if (logHeartbeatCounter > 1.0f)
        {
            seconds += 1;
            logHeartbeatCounter -= 1.0f;

            Log.LogInfo($"Plugin {MyPluginInfoString.Value()} has been running for {seconds} seconds!");
        }
    }
}
