New-Item C:\temp\docs\ -Force -ItemType Directory
Copy-Item .\docs\build\Html\default\* C:\temp\docs\

git checkout gh-pages -f
Remove-Item .\* -Recurse -Exclude .git\*, CNAME
Copy-Item C:\temp\docs\* .\

git add .
git commit -m ('Docs v' + $Env:APPVEYOR_BUILD_VERSION)
git push ('https://' + $Env:GITHUB_TOKEN + '@github.com/arthurrump/Zermelo.API.git') gh-pages

Remove-Item C:\temp\docs -Recurse