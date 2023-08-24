using CefSharp;
using Flurl;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace GenericBrowser
{
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
            case GET:
                Application.Current
                    .Dispatcher.InvokeAsync( async () => {
                        var mainWindow = Application.Current.MainWindow as MainWindow;
                        var defaultBrush = mainWindow!.AddressBarGrid.Background;

                        for ( int i = 0; i < 3; i++ ) {
                            mainWindow!.AddressBarGrid.Background = Brushes.Red;
                            await Task.Delay( 300 );
                            mainWindow!.AddressBarGrid.Background = defaultBrush;
                            await Task.Delay( 300 );
                        }
                    } );
                break;

            case POST:
                var json =
                    Url.Decode(
                        request.PostData?.Elements
                        .FirstOrDefault( x => x.Type == PostDataElementType.Bytes )
                        ?.GetBody()
                        ?? string.Empty
                        , true );

                Application.Current
                    .Dispatcher.Invoke( () => {
                        MessageBox.Show(
                            Application.Current.MainWindow
                            , json
                            , "POST Data" );
                    } );
                break;
            }

            return
                new EmptyResourceHandler(); // just OK 200
        }

        public const string SchemaName = "bro";
        private const string GET = "GET";
        private const string POST = "POST";
    }
}
