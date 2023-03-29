# https://thunderstore.io/package/create/docs/

. "scripts/environment.ps1"

Remove-Item -Path $localPackagePath -Recurse -Force -ErrorAction SilentlyContinue
New-Item -Path $localPackagePath -ItemType Directory -Force

Copy-Item "icon.png" $localPackagePath
Copy-Item "README.md" $localPackagePath
Copy-Item "CHANGELOG.md" $localPackagePath

dotnet build

$replacements = @{
    '{$$|name|$$}' = $pluginName
    '{$$|version|$$}' = $version
    '{$$|description|$$}' = $description
}
Get-Content "./manifest.json" `
  | ForEach-Object {
    $line = $_
    foreach ($key in $replacements.Keys) {
        $line = $line -replace [regex]::Escape($key), $replacements[$key]
    }
    $line
  } `
  | Set-Content "$localPackagePath/manifest.json"

Copy-Item "$pluginName/bin/Debug/net6.0/$pluginName.dll" $localPackagePath

Remove-Item -Path $zipPath -Recurse -Force -ErrorAction SilentlyContinue
Compress-Archive "$localPackagePath/*" $zipPath
