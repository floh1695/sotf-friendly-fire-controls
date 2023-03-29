# https://thunderstore.io/package/create/docs/

$packageRoot = "package"
Remove-Item -Path $packageRoot -Recurse -Force -ErrorAction SilentlyContinue
New-Item -Path $packageRoot -ItemType Directory -Force

Copy-Item "icon.png" $packageRoot
Copy-Item "README.md" $packageRoot
Copy-Item "CHANGELOG.md" $packageRoot

dotnet build
$pluginName = "FriendlyFireControls"
$version = Get-Content "$pluginName/$pluginName.csproj" `
  | Select-String -Pattern '<Version>(.*?)<\/Version>' `
  | Foreach-Object {$_.Matches.Groups[1].Value}
$replacements = @{
    '{$$|version|$$}' = $version
}
Get-Content "./manifest.json" `
  | ForEach-Object {
    $line = $_
    foreach ($key in $replacements.Keys) {
        $line = $line -replace [regex]::Escape($key), $replacements[$key]
    }
    $line
  } `
  | Set-Content "$packageRoot/manifest.json"

Copy-Item "$pluginName/bin/Debug/net6.0/$pluginName.dll" $packageRoot

$zipName = "$pluginName.zip"
Remove-Item -Path $zipName -Recurse -Force -ErrorAction SilentlyContinue
Compress-Archive "$packageRoot/*" $zipName
