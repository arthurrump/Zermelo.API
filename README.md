# Zermelo.API - Connect to Zermelo from your .NET app

Disclaimer: this project is created by a third party and not associated with Zermelo Software BV.

Zermelo.API is a PCL (Portable Class Library, a Library of Classes that is Portable (can be used on multiple platforms)) that provides a .NET API to connect to the Zermelo API. The Zermelo API is an API created by Zermelo Software that allows third parties to integrate with their scheduling software that's used by many Dutch schools. This PCL abstracts the Zermelo API into easy to use methods and classes that can be used by a .NET application.

## Links
- [NuGet](https://www.nuget.org/packages/Zermelo.API)
- [Documentation](http://arthurrump.github.io/zermelo.api)
- [Source on GitHub](https://github.com/arthurrump/Zermelo.API)

## Projects using this library
- Schoolrooster voor Zermelo ([Microsoft Store](https://www.microsoft.com/store/apps/9nblggh5fdl2))

Have you created a very cool project, that should absolutely be listed here? Just add it and create a Pull Request!

## FAQ
### What version of the API is supported?
Currently this library supports version 2 of the API.

### How much of the API is supported?
This library supports (as far as I know) every part of the API that can be accessed when authenticated by an authorization code. This means you can access the Announcements, Appointments and Users endpoints. When using the library you'll also see an Authentication endpoint, but this is not directly linked to an endpoint over at the Zermelo API.

### Why are GitHub issues disabled?
This project has been a private project for quite some time. All this time I used [Visual Studio Team Services](https://www.visualstudio.com/products/visual-studio-team-services-vs) to host my code and work items (the VSTS version of issues, but way better), and VSTS is a pretty great (understatement) service, so I didn't want to give up all the things of VSTS in favor of open source. Currently the code is synced between VSTS and GitHub, so I can enjoy using VSTS and you can enjoy the code too, but as the issues workflow of VSTS and GitHub is very different, I haven't found a way to sync it yet. This might change in the future (the VSTS team is working hard on customization options for the work items workflow), but untill then the GitHub issues will remain disabled.