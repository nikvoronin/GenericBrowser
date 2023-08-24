using CefSharp;
using CefSharp.Wpf;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace GenericBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DefaultAddressBarGridBrush = AddressBarGrid.Background;
        }

        readonly Brush DefaultAddressBarGridBrush;
        ILifeSpanHandler? _defaultLifeSpanHandler = null;
        IContextMenuHandler? _contextMenuHandler = null;

        private void Window_Loaded( object sender, RoutedEventArgs e )
        {
            Title = $"{Title} — Chromium v{Cef.ChromiumVersion}";
            BrowserAddress.Focus();

            // disable popups windows at all
            // but store the default one
            // so we can always revert it to the default behavior
            _defaultLifeSpanHandler = Browser.LifeSpanHandler;
            Browser.LifeSpanHandler = new DisablePopupLifeSpan();

            // disable context menu by right mouse button
            _contextMenuHandler = Browser.MenuHandler;
            //Browser.MenuHandler = new DisableContextMenuHandler();

            // redirect messages of the browser control to an application defined logger
            // do not confuse with the log from CEF core component which configured in CefSettings
            //Browser.ConsoleMessage += ( sender, args )
            //    => _logger.LogDebug(
            //        "{0}|{1}({2}): {3}"
            //        , args.Level
            //        , args.Source
            //        , args.Line
            //        , args.Message );

            Browser.FrameLoadStart += Browser_FrameLoadStart;
            Browser.FrameLoadEnd += Browser_FrameLoadEnd;

            BrowseToStartPage();
        }

        private void BrowseToStartPage()
        {
            var homeUrl =
                "file:///"
                + Path.Combine(
                    AppContext.BaseDirectory
                    , "index.html" );

            Browser.Address = homeUrl;
        }

        private async void Browser_FrameLoadEnd( object? sender, FrameLoadEndEventArgs e )
        {
            Dispatcher.Invoke( () => {
                FrameUrlHintLabel.Content = null;
            } );

            var isMainFrame = e.Frame?.IsMain ?? false;
            if ( !isMainFrame ) return;

            await UpdateAddressBarBackground();
            await UpdateTitle();
        }

        private async Task UpdateAddressBarBackground()
        {
            try {
                var mainFrame = Browser.GetMainFrame();
                if ( mainFrame is null ) return;

                var r =
                    await mainFrame!.EvaluateScriptAsync(
                        "window.getComputedStyle( document.body ).backgroundColor" );
                if ( r.Failed() ) return;

                if ( r!.Result is string bg ) {
                    var sharpColorString =
                        Styler.SharpColorFrom( bg );

                    Dispatcher.Invoke( () => {
                        AddressBarGrid.Background =
                            sharpColorString is not null
                            ? new BrushConverter().ConvertFrom( sharpColorString ) as Brush
                            : DefaultAddressBarGridBrush;
                    } );
                }
            }
            catch { }
        }

        private async Task UpdateTitle()
        {
            try {
                var mainFrame = Browser.GetMainFrame();
                if ( mainFrame is null ) return;

                var r = await mainFrame.EvaluateScriptAsync( "document.title" );
                if ( r.Failed() ) return;

                if ( r!.Result is string title ) {
                    Dispatcher.Invoke( () => {
                        Title = $"{title} — Chromium v{Cef.ChromiumVersion}";
                    } );
                }
            }
            catch { }
        }

        private void Browser_FrameLoadStart( object? sender, FrameLoadStartEventArgs e )
        {
            Dispatcher.Invoke( () => {
                FrameUrlHintLabel.Content = e.Url;
            } );
        }

        private void RefreshBrowserButton_Click( object sender, RoutedEventArgs e )
        {
            Browser.WebBrowser.Reload( true );
        }

        private void BackBrowserButton_Click( object sender, RoutedEventArgs e )
        {
            Browser.WebBrowser.Back();
        }

        private void ForwardBrowserButton_Click( object sender, RoutedEventArgs e )
        {
            Browser.WebBrowser.Forward();
        }

        private void BrowserAddress_KeyUp( object sender, KeyEventArgs e )
        {
            if(e.Key == Key.Enter)
                Browser.Address = BrowserAddress.Text;
        }

        private void DevToolButton_Click( object sender, RoutedEventArgs e )
        {
            Browser.ShowDevTools();
        }

        private void HomeBrowserButton_Click( object sender, RoutedEventArgs e )
        {
            BrowseToStartPage();
        }
    }
}
