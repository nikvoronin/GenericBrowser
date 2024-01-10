# Generic Browser

`CEFsharp` is a .NET (WPF and Windows Forms) bindings for the `Chromium Embedded Framework`. This project is an example of a minimal Chromium based browser written under the both `Windows Forms` and `WPF`.

- [Features](#features)
- [Recommended Reading List](#recommended-reading-list)
- [Alternatives](#alternatives)
- [Examples](#examples)
  - [Create browser control WinForms](#create-browser-control-winforms)
  - [Styling control with html-body color](#styling-control-with-html-body-color)
  - [Custom protocol scheme](#custom-protocol-scheme)
  - [Take a screenshot](#take-a-screenshot)
  - [Disable pop-up windows](#disable-pop-up-windows)
  - [Disable context menu](#disable-context-menu)

![WinForms GenericBrowser](https://user-images.githubusercontent.com/11328666/263242161-e9f0a14a-5fda-415c-80df-d9a03df8ee72.png)

See also [CefSharp.MinimalExample](https://github.com/cefsharp/CefSharp.MinimalExample) project.

## Features

### User

- Local web-page `index.html` for local experiments
  - Links to test web services.
  - POST form to fetch POST requests.
  - Button to fetch GET requests.
- Address bar with Google search ability.
- 🖨 Print-to-PDF.
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

## Examples

![Let's build from here](https://user-images.githubusercontent.com/11328666/263079291-1317b687-2917-4182-835b-aedebfa123ea.png)

### Create browser control WinForms

The `browserPanel` could be a Form (ie window as is) or container Panel inside a form or even Control.

```csharp
public partial class MainForm : Form
{
    ChromiumWebBrowser _browserControl = new ();

    public MainForm()
    {
        InitializeComponent();

        // Add it to the form and fill it to the form window.
        browserPanel.Controls.Add( _browserControl );
        _browserControl.Dock = DockStyle.Fill;
    }
    ...
```

### Styling control with html-body color

It also describes how to inject javascript and evaluate its results.

```csharp
var mainFrame = _browserControl.GetMainFrame();
if (mainFrame is null) return;

var r =
    await mainFrame!.EvaluateScriptAsync(
        "window.getComputedStyle( document.body ).backgroundColor" );
if (r.Failed()) return;

if (r!.Result is string bg) {
    var bs =
        Styler.ToRgbBytes( bg );

    if (bs is not null) {
        Invoke( () => {
            navigationLayoutPanel.BackColor =
                bs.All( b => b == 0 ) ? SystemColors.Control
                : Color.FromArgb( bs[0], bs[1], bs[2] );
        } );
    }
}
```

### Custom protocol scheme

#### Register scheme

Let it be a brand new scheme `bro://` (named after a BROwser).

```csharp
var settings = new CefSettings();

settings.RegisterScheme(
    new CefCustomScheme() {
        SchemeName = "bro"
        , SchemeHandlerFactory = new BroSchemaHandlerFactory()
        , IsFetchEnabled = true
        , IsCorsEnabled = true
    } );

// Apply new settings
if (!Cef.IsInitialized) {
    Cef.Initialize(
        settings
        , performDependencyCheck: true
        , browserProcessHandler: null );
}
```

#### Handle scheme requests

```csharp
public class BroSchemaHandlerFactory : ISchemeHandlerFactory
{
    public IResourceHandler Create( IBrowser browser, IFrame frame, string schemaName, IRequest request )
    {
        var u = Url.Parse( request.Url );
        var schemaMismatch =
            schemaName != SchemaName
            || u.Scheme != schemaName;

        if ( schemaMismatch ) return new ResourceHandler();

        var method = request.Method.ToUpper();
        switch ( method ) {
        case "GET": break;
        case "POST": break;
        }
        ...
```

### Take a screenshot

⚠ WinForms or headless/windowless versions only.

```csharp
var contentSize = await _browserControl.GetContentSizeAsync();

var viewPort = new CefSharp.DevTools.Page.Viewport {
    Width = contentSize.Width,
    Height = contentSize.Height,
};

var data =
    await _browserControl.CaptureScreenshotAsync(
        viewPort: viewPort
        , captureBeyondViewport: true );

File.WriteAllBytes( $"image_{DateTime.Now.Ticks}.jpeg", data );
```

### Disable pop-up windows

```csharp
_browserControl.LifeSpanHandler = new DisablePopupLifeSpan();
```

#### Custom ILifeSpanHandler

```csharp
public class DisablePopupLifeSpan : ILifeSpanHandler
{
    public void OnAfterCreated( IWebBrowser chromiumWebBrowser, IBrowser browser ) { }
    public void OnBeforeClose( IWebBrowser chromiumWebBrowser, IBrowser browser ) { }

    public bool DoClose( IWebBrowser chromiumWebBrowser, IBrowser browser )
        => false;

    public bool OnBeforePopup( IWebBrowser chromiumWebBrowser, ..., out IWebBrowser newBrowser )
    {
        newBrowser = null!;
        return true; // do not popup
    }
}
```

### Disable context menu

Also known as context menu.

```csharp
_browserControl.MenuHandler = new DisableContextMenuHandler();
```

#### Custom IContextMenuHandler

```csharp
public class DisableContextMenuHandler : IContextMenuHandler
{
    public void OnContextMenuDismissed( IWebBrowser chromiumWebBrowser, ... ) { }

    public void OnBeforeContextMenu( IWebBrowser chromiumWebBrowser, ..., IMenuModel model )
    {
        model.Clear();
    }

    public bool OnContextMenuCommand( IWebBrowser chromiumWebBrowser, ... )
        => false;

    public bool RunContextMenu( IWebBrowser chromiumWebBrowser, ... )
        => false;
}
```
