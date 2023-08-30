# Generic Browser

`CEFsharp` is a .NET (WPF and Windows Forms) bindings for the `Chromium Embedded Framework`. This project is an example of a minimal Chromium based browser written under the both `Windows Forms` and `WPF`.

- [Features](#features)
- [Recommended Reading List](#recommended-reading-list)
- [Alternatives](#alternatives)
- [Examples🚧](#examples)

![WinForms GenericBrowser](https://user-images.githubusercontent.com/11328666/263242161-e9f0a14a-5fda-415c-80df-d9a03df8ee72.png)

See also [CefSharp.MinimalExample](https://github.com/cefsharp/CefSharp.MinimalExample) project.

## Features

### User

- Local web-page `index.html` for local experiments
  - Links to test web services.
  - POST form to fetch POST requests.
  - Button to fetch GET requests.
- Address bar with Google search ability.
- 📸 Screenshots with save dialog.
- ⚡ DevTools for developers.
- Standart navigation buttons: ◀ back, ▶ forward, 🏠 home, ↻ reload.
- Status bar to show address of hover links.

### Developer

- WinForms or WPF
- Latest Chromium browser core.
- Possibility to implement protocol for a custom scheme. For ex. implement handler to load from `gemini://gemini.circumlunar.space/`.
- Enable/disable popup windows.
- Enable/disable context menu (right mouse click).
- Disable GPU acceleration to optimize for integrated graphics adapters.
- Change UserAgent.
- Enable/Disable CORS and the `fetch` function.
- Logging from low-level to up to javascript console messages.
- Enable/Disable plugins.
- Inject and execute javascripts on the fly.

## Recommended Reading List

### CEFsharp

- [General Usage CEFsharp](https://github.com/cefsharp/CefSharp/wiki/General-Usage). This guide introduces the general concepts involved when developing an application using CefSharp. It's important to remember that CefSharp is a .Net wrapper around the Chromium Embedded Framework (CEF). CEF is an open source project based on the Google Chromium project. Unlike the Chromium project itself, which focuses mainly on Google Chrome application development, CEF focuses on facilitating embedded browser use cases in third-party applications.
- [Build CEF with proprietary codecs support](https://magpcss.org/ceforum/viewtopic.php?f=6&t=13515). I would like to build CEF xxxx (current master branch) for Windows (x64, Visual Studio 20xx) with proprietary codec support.
- [Building CefSharp](https://github.com/cefsharp/CefSharp/wiki/Building-CefSharp).

### Chromium Embedded Framework (CEF)

- [Master Build Quick Start](https://bitbucket.org/chromiumembedded/cef/wiki/MasterBuildQuickStart). This Wiki page provides a quick-start guide for creating a Debug build of CEF/Chromium using the current master (development) branch.
- [Automated Build Setup](https://bitbucket.org/chromiumembedded/cef/wiki/AutomatedBuildSetup). CEF provides tools for automatically downloading, building and packaging Chromium and CEF source code. These tools are the recommended way of building CEF locally and can also be integrated with an automated build system.

## Alternatives

- [Microsoft Edge WebView2](https://developer.microsoft.com/en-us/microsoft-edge/webview2/)
- [TeamDev DotNetBrowser](https://dotnetbrowser-support.teamdev.com/)

## Examples🚧

![Let's build from here](https://user-images.githubusercontent.com/11328666/263079291-1317b687-2917-4182-835b-aedebfa123ea.png)

- stylling toolbar to sync its backgroud with web-site body color.
- `bro://` custom scheme with GET and POST handlers.
- screenshots
- logging
- disable popups and right-click-menu.
- inject javascripts then evaluate its results.
