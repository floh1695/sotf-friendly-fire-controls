namespace FriendlyFireControls;

public static class MyPluginInfoString
{
    public static string Value() =>
        string.Format(
            "{0}--{1}--{2}",
            MyPluginInfo.PLUGIN_GUID,
            MyPluginInfo.PLUGIN_NAME,
            MyPluginInfo.PLUGIN_VERSION
        );
}
