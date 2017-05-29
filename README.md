# Zermelo.API - Connect to Zermelo from your .NET app

*Note: this project is created by a third party and not affiliated with Zermelo Software B.V. in any way.*

![Zermelo.API](/logo/logo.png)

<table style="width: auto">
<thead>
<tr>
  <th>Build status</th>
  <th></th>
</tr>
</thead>
<tbody>
<tr>
  <td>master</td>
  <td><a href="https://ci.appveyor.com/project/arthurrump/zermelo-api/branch/master"><img src="https://ci.appveyor.com/api/projects/status/h4l0t4ch01pgtr33/branch/master?svg=true" alt="Build status" title=""></a></td>
</tr>
<tr>
  <td>dev</td>
  <td><a href="https://ci.appveyor.com/project/arthurrump/zermelo-api/branch/dev"><img src="https://ci.appveyor.com/api/projects/status/h4l0t4ch01pgtr33/branch/dev?svg=true" alt="Build status" title=""></a></td>
</tr>
</tbody>
</table>

Zermelo.API is a .NET library for easier interaction with the Zermelo REST API, which gives access to scheduling information of the many Dutch schools that use Zermelo software to create their schedules. This library can be used on every .NET platform supporting .NET Standard 1.1 and up, so it runs on .NET Core 1+, .NET Framework 4.5+, Mono 4.6+, Xamarin, UWP and many more.

## Links
- [NuGet](https://www.nuget.org/packages/Zermelo.API)
- [Documentation](http://zermelo.api.arthurrump.com)
- [Source on GitHub](https://github.com/arthurrump/Zermelo.API)
- [CI builds on AppVeyor](https://ci.appveyor.com/project/arthurrump/zermelo-api)

## Projects using this library
- Schoolrooster voor Zermelo ([GitHub](https://github.com/arthurrump/Zermelo.App.UWP), [Website](http://schoolrooster.arthurrump.com))

Have you created a very cool project, that should absolutely be listed here? Just add it and create a Pull Request!

## FAQ
### What version of the API is supported?
Currently this library supports version 3 of the API.

### How much of the API is supported?
This library supports every part of the [documented](http://developers.zermelo.nl) REST API, but also some undocumented endpoints which are used by the [official Zermelo app](https://github.com/zermelo-software/zermelo-app). Documentation of those endpoints is therefore based on educated guesses and might not be completely right. A list of known, but unsupported enpoints can be found in [issue #11](https://github.com/arthurrump/Zermelo.API/issues/11).
