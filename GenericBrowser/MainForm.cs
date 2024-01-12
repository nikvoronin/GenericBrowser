using CefSharp;
using CefSharp.WinForms;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenericBrowser
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeBrowserControl();
        }

        private void InitializeBrowserControl()
        {
            // Add it to the form and fill it to the form window.
            browserPanel.Controls.Add( _browserControl );
            _browserControl.Dock = DockStyle.Fill;
        }

        protected override void OnLoad( EventArgs e )
        {
            Text = $"{Text} — Chromium v{Cef.ChromiumVersion}";
            addressTextBox.Focus();

            // disable popups windows at all but store a default handler
            // so we can always revert it to the default behavior
            _defaultLifeSpanHandler = _browserControl.LifeSpanHandler;
            _browserControl.LifeSpanHandler = new DisablePopupLifeSpan();

            // disable context menu by right mouse button
            _contextMenuHandler = _browserControl.MenuHandler;
            //Browser.MenuHandler = new DisableContextMenuHandler();

            // redirect messages of the browser control to an application defined logger
            // do not confuse with the log from CEF core component which configured in CefSettings
            //_browserControl.ConsoleMessage += ( sender, args )
            //    => _logger.LogDebug(
            //        "{0}|{1}({2}): {3}",
            //        args.Level,
            //        args.Source,
            //        args.Line,
            //        args.Message );

            _browserControl.FrameLoadStart += ( s, e ) => UrlStatusLabel = e.Url;
            _browserControl.FrameLoadEnd += BrowserControl_FrameLoadEnd;
            _browserControl.LoadingStateChanged += BrowserControl_LoadingStateChanged;

            _browserControl.StatusMessage += ( s, e ) => {
                UrlStatusLabel =
                    string.IsNullOrEmpty( e.Value ) ? "Ready"
                    : e.Value;
            };

            _browserControl.TitleChanged += ( s, e ) =>
                Invoke( () => { Text = $"{e.Title} — Chromium v{Cef.ChromiumVersion}"; } );

            BrowseToStartPage();
        }

        private void BrowserControl_LoadingStateChanged( object? sender, LoadingStateChangedEventArgs e )
        {
            Invoke( () => {
                backwardButton.Enabled = e.CanGoBack;
                forwardButton.Enabled = e.CanGoForward;
                updateButton.Enabled = e.CanReload;
            } );

            if (!e.IsLoading)
                Invoke( () => { addressTextBox.Text = _browserControl.Address; } );
        }

        private void BrowseToStartPage()
        {
            var homeUrl =
                "file:///"
                + Path.Combine(
                    AppContext.BaseDirectory
                    , "index.html" );

            _browserControl.Load( homeUrl );
        }

        private string UrlStatusLabel {
            set => Invoke( () => { urlStatusLabel.Text = value; } );
        }

        private async void BrowserControl_FrameLoadEnd( object? sender, FrameLoadEndEventArgs e )
        {
            var isMainFrame = e.Frame?.IsMain ?? false;
            if (!isMainFrame) return;

            UrlStatusLabel = "Ready";

            await UpdateAddressBarBackground();
            // await UpdateTitle();
        }

        private async Task UpdateAddressBarBackground()
        {
            try {
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
            }
            catch { }
        }

        private async Task UpdateTitle()
        {
            try {
                var mainFrame = _browserControl.GetMainFrame();
                if (mainFrame is null) return;

                var r = await mainFrame.EvaluateScriptAsync( "document.title" );
                if (r.Failed()) return;

                if (r!.Result is string title) {
                    Invoke( () => {
                        Text = $"{title} — Chromium v{Cef.ChromiumVersion}";
                    } );
                }
            }
            catch { }
        }

        protected override void OnFormClosing( FormClosingEventArgs e )
        {
            _browserControl.Dispose();
            base.OnFormClosing( e );
        }

        private void HomeButton_Click( object sender, EventArgs e )
            => BrowseToStartPage();

        private void UpdateButton_Click( object sender, EventArgs e )
            => _browserControl.Reload( true );

        private void ForwardButton_Click( object sender, EventArgs e )
            => _browserControl.Forward();

        private void BackwardButton_Click( object sender, EventArgs e )
            => _browserControl.Back();

        private async void ScreenshotButton_Click( object sender, EventArgs e )
            => await TakeScreenshot();

        private async void SavePageAsPdfButton_Click( object sender, EventArgs e )
        {
            var dialog =
                new SaveFileDialog {
                    DefaultExt = "pdf",
                    Filter = "PDF file (*.pdf)|*.pdf|Any files (*.*)|*.*",
                    FileName = DateTime.Now.Ticks.ToString()
                };

            if (dialog.ShowDialog() == DialogResult.OK) {
                await _browserControl.GetMainFrame().Browser
                    .PrintToPdfAsync( dialog.FileName );
            }
        }

        private void PrintPageButton_Click( object sender, EventArgs e )
        {
            _browserControl.GetMainFrame().Browser.Print();
        }

        private async Task TakeScreenshot()
        {
            var contentSize = await _browserControl.GetContentSizeAsync();

            var viewPort = new CefSharp.DevTools.Page.Viewport {
                Width = contentSize.Width,
                Height = contentSize.Height,
            };

            var data =
                await _browserControl.CaptureScreenshotAsync(
                    viewPort: viewPort, 
                    captureBeyondViewport: true );

            var dialog =
                new SaveFileDialog {
                    DefaultExt = "jpeg",
                    Filter = "PNG lossless image file (*.png)|*.png|JPEG compressed image file (*.jpg,*.jpeg)|*.jpg;*.jpeg|Any files (*.*)|*.*",
                    FileName = DateTime.Now.Ticks.ToString()
                };

            if (dialog.ShowDialog() == DialogResult.OK)
                File.WriteAllBytes( dialog.FileName, data );
        }

        private void DevtoolsButton_Click( object sender, EventArgs e )
            => _browserControl.ShowDevTools();

        private void AddressTextBox_KeyUp( object sender, KeyEventArgs e )
        {
            if (e.KeyCode != Keys.Enter) return;

            InternalNavigateTo( addressTextBox.Text );
        }

        private void InternalNavigateTo( string urlString )
        {
            // No action unless the user types in some sort of url
            if (string.IsNullOrEmpty( urlString )) {
                return;
            }

            var success =
                Uri.TryCreate(
                    urlString
                    , UriKind.RelativeOrAbsolute
                    , out Uri? url );

            // Basic parsing was a success, now we need to perform additional checks
            if (success) {
                // Load absolute urls directly.
                // You may wish to validate the scheme is http/https
                // e.g. url.Scheme == Uri.UriSchemeHttp || url.Scheme == Uri.UriSchemeHttps
                if (url!.IsAbsoluteUri) {
                    _browserControl.LoadUrl( urlString );

                    return;
                }

                // Relative Url
                // We'll do some additional checks to see if we can load the Url
                // or if we pass the url off to the search engine
                var hostNameType = Uri.CheckHostName( urlString );

                if (hostNameType == UriHostNameType.IPv4 || hostNameType == UriHostNameType.IPv6) {
                    _browserControl.LoadUrl( urlString );

                    return;
                }

                if (hostNameType == UriHostNameType.Dns) {
                    try {
                        var hostEntry = Dns.GetHostEntry( urlString );
                        if (hostEntry.AddressList.Length > 0) {
                            _browserControl.LoadUrl( urlString );

                            return;
                        }
                    }
                    catch (Exception) {
                        // Failed to resolve the host
                    }
                }
            }

            // Failed parsing load urlString is a search engine
            var searchUrl = "https://www.google.com/search?q=" + Uri.EscapeDataString( urlString );

            _browserControl.LoadUrl( searchUrl );
        }

        readonly ChromiumWebBrowser _browserControl = new();
        private ILifeSpanHandler? _defaultLifeSpanHandler;
        private IContextMenuHandler? _contextMenuHandler;
    }
}
