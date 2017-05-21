$sdoxPath = (Get-Item .\docs\zermelo.sdox).FullName

$versionNumber = $Env:APPVEYOR_BUILD_VERSION
$fullLogoPath = (Get-Item .\docs\logo.png).FullName
$fullInputFilePath = (Get-Item .\docs\default.sdnav).FullName
$fullOutputPath = (Get-Item .\docs).FullName + '\build'

$sdox = Get-Content $sdoxPath
$sdox = $sdox -replace '<!--VersionNumber-->', $versionNumber
$sdox = $sdox -replace '<!--FullLogoPath-->', $fullLogoPath
$sdox = $sdox -replace '<!--FullInputFilePath-->', $fullInputFilePath
$sdox = $sdox -replace '<!--FullOutputPath-->', $fullOutputPath
$sdox | Out-File $sdoxPath -Encoding utf8

Copy-Item README.md docs\default.sdpd

C:\tools\sharpdox\sharpdox\SharpDox.Console.exe -Config $sdoxPath

Remove-Item docs\build\Html\default\start.exe