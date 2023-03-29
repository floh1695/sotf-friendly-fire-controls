. "scripts/environment.ps1"

& "scripts/package.ps1"

New-Item -Path $gamePluginsPath -ItemType Directory -Force
New-Item -Path $gamePluginPath -ItemType Directory -Force

Copy-Item "$localPackagePath/*" $gamePluginPath
