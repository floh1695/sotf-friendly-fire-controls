. "scripts/environment.ps1"

New-Item -Path $referencesPath -ItemType Directory -Force

$referencePaths = "core", "interop", "unity-libs"
$referencePaths | ForEach-Object {
  $referencePath = "$referencesPath/$_"
  Remove-Item -Path $referencePath -Recurse -Force -ErrorAction SilentlyContinue
  Copy-Item -Recurse "$bepInExPath/$_" $referencePath
}
