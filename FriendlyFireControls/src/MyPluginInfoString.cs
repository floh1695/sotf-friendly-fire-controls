namespace FriendlyFireControls;

public static class MyPluginInfoString
{
    public static string Value() =>
        string.Format(
            "{}--{}--{}",
            MyPluginInfo.PLUGIN_GUID,
            MyPluginInfo.PLUGIN_NAME,
            MyPluginInfo.PLUGIN_VERSION
        );
}
