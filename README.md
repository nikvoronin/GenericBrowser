# Generic Browser

`CEFsharp` is a .NET (WPF and Windows Forms) bindings for the `Chromium Embedded Framework`. This project is an example of a minimal custom brewed Chromium based browser written under the both `Windows Forms` and `WPF`.

![image](https://github.com/nikvoronin/GenericBrowser/assets/11328666/c21acc8f-386f-48c7-bd3d-9383c96635ac)

See also [CefSharp.MinimalExample](https://github.com/cefsharp/CefSharp.MinimalExample) project.

## Features

## User

- Local web-page `index.html` for local experiments
  - Links to test web services.
  - POST form to fetch POST requests.
  - Button to fetch GET requests.
- Address bar with Google search ability.
- 📸 Screenshots with save dialog.
- ⚡ DevTools for developers.
- Standart navigation buttons: ◀ back, ▶ forward, ↻ reload, 🏠 home.
- Status bar to show address of hover links.

### Developer

- WinForms or WPF
- Latest Chromium browser core.
- Possibility to implement a custom protocol. For ex. we could implement handler to load from `gemini://gemini.circumlunar.space/`.
- Enable/disable popup windows.
- Enable/disable context menu (right mouse click).
- Disable GPU acceleration to optimize for integrated graphics adapters.
- Change UserAgent.
- Enable/Disable CORS and the `fetch` function.
- Logging from low-level to up to javascript console messages.
- Enable/Disable plugins.
- Inject and execute javascripts on the fly.

## Examples

🚧 WIP
