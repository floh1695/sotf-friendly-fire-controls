dotnet build

$gamePath = "C:\Program Files (x86)\Steam\steamapps\common\Sons Of The Forest"

$pluginPath = "$gamePath/BepInEx/plugins"
New-Item -Path $pluginPath -ItemType Directory -Force

$pluginName = "FriendlyFireControls"
$pluginDll = "$pluginName.dll"
$pluginSource = "$pluginName/bin/Debug/net6.0/$pluginDll"
$pluginTarget = "$pluginPath/$pluginDll"
Copy-Item $pluginSource $pluginTarget
