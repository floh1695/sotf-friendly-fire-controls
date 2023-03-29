$gameName = "Sons Of The Forest"
$pluginName = "FriendlyFireControls"

$steamPath = "C:\Program Files (x86)\Steam"
$steamGamesPath = "$steamPath/steamapps\common"
$gamePath = "$steamGamesPath\$gameName"
$bepInExPath = "$gamePath/BepInEx"
$gamePluginsPath = "$bepInExPath/plugins"
$gamePluginPath = "$gamePluginsPath/$pluginName"

$localPackagePath = "package"

$pluginCsproj = "$pluginName/$pluginName.csproj"
$version = Get-Content $pluginCsproj `
  | Select-String -Pattern '<Version>(.*?)<\/Version>' `
  | Foreach-Object {$_.Matches.Groups[1].Value}
$description = Get-Content $pluginCsproj `
  | Select-String -Pattern '<Description>(.*?)<\/Description>' `
  | Foreach-Object {$_.Matches.Groups[1].Value}

$zipPath = "$pluginName.zip"

$referencesPath = "references"
