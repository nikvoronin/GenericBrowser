using CefSharp;
using CefSharp.Internals;
using CefSharp.Wpf;
using System;
using System.Windows;

namespace GenericBrowser
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            ConfigureCef();
        }

        private static void ConfigureCef()
        {
            var settings = new CefSettings();

            //ConfigureLogger( settings );

            // this would change the default UserAgent
            //settings.UserAgent = UserAgent_Chrome104;

            settings.EnablePrintPreview();

            // would be able to accept custom protocol requests
            // bro://actions/and/requests?yes&we&can
            settings.RegisterScheme(
                new CefCustomScheme() {
                    SchemeName = BroSchemaHandlerFactory.SchemaName,
                    SchemeHandlerFactory = new BroSchemaHandlerFactory(),
                    IsFetchEnabled = true,
                    IsCorsEnabled = true,
                } );


            var cef_args = settings.CefCommandLineArgs;

            // common settings
            
            cef_args.Add( "disable-plugins-discovery", CefTrue );
            cef_args.Add( "renderer-process-limit", CefTrue );
            cef_args.Add( "debug-plugin-loading", CefTrue );
            cef_args.Add( "enable-media-stream", CefTrue );
            cef_args.Add( "use-fake-ui-for-media-stream" );
            cef_args.Add( "enable-usermedia-screen-capturing" );

            // Would disable GPU acceleration.
            // Sometimes it is good fit for Intel Integrated Graphics adapters
            //DisableGpuAcceleration( cef_args, settings );

            // Apply new settings
            if ( !Cef.IsInitialized ) {
                Cef.Initialize(
                    settings
                    , performDependencyCheck: true
                    , browserProcessHandler: null );
            }
        }

        private static void ConfigureLogger( CefSettings cefSets )
        {
            cefSets.LogFile = "logs/_cefsharp.log";

            // see LogLevelExtensions.cs to convert severity from Serilog or NLog log levels
            cefSets.LogSeverity = LogSeverity.Default;
        }

        private static void DisableGpuAcceleration(
            CommandLineArgDictionary cefArgs
            , CefSettings cefSets)
        {
            cefArgs.Add( "disable-gpu", CefTrue );
            cefArgs.Add( "disable-gpu-vsync", CefTrue );
            cefArgs.Add( "disable-gpu-compositing", CefTrue );
            cefArgs.Add( "enable-begin-frame-scheduling", CefTrue );

            cefSets.DisableGpuAcceleration();
            cefSets.SetOffScreenRenderingBestPerformanceArgs();
        }

        public const string CefTrue = "1";
        public const string CefFalse = "0";
        public const string UserAgent_Chrome104 =
            "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/104.0.0.0 Safari/537.36";
        public const string UserAgent_SmartTV_AncientChrome52 =
            "Mozilla/5.0 (X11; Linux armv7l) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.84 Safari/537.36 CrKey/1.22.78594";

    }
}
