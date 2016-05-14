Copy-Item README.md docs\default.sdpd
.\docs\tools\sharpdox\SharpDox.Console.exe -Config (Get-Item .\docs\zermelo.sdox).FullName
Remove-Item docs\build\Html\default\start.exe