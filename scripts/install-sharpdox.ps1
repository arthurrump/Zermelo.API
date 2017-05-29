$version = '1.2.2'
$path = 'C:\tools\sharpdox'
$url = 'https://github.com/geaz/sharpDox/releases/download/v' + $version + '/sharpDox.' + $version + '.zip'

function Install-SharpDox {
    Write-Host 'Installing SharpDox version' $version '...'

    Invoke-WebRequest $url -OutFile ($path + '.zip')
    Expand-Archive ($path + '.zip') $path
    Remove-Item ($path + '.zip')
    Get-ChildItem $path | Rename-Item -NewName sharpdox
    $version | Out-File ($path + '\version.txt') -NoNewline

    Write-Host 'Done.'
}

if (Test-Path ($path + '\version.txt')) {
    $installedVersion = Get-Content ($path + '\version.txt')
    Write-Host 'SharpDox version' $installedVersion 'is already installed.'

    if ($installedVersion -ne $version) {
        Remove-Item ($path + '\*') -Recurse
        Install-SharpDox
    }
}
else {
    Install-SharpDox
}