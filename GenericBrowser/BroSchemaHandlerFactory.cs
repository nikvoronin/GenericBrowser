using CefSharp;
using Flurl;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows;

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
                for (int i = 0; i < 3; i++) {
                    AppHelper.MainWindow!.Invoke( () => {
                        AppHelper.MainWindow!.NavigationPanel.BackColor =
                        Color.Red;
                    } );

                    Thread.Sleep( 300 );

                    AppHelper.MainWindow!.Invoke( () => {
                        AppHelper.MainWindow!.NavigationPanel.BackColor =
                        System.Drawing.SystemColors.Control;
                    } );

                    Thread.Sleep( 300 );
                }
                break;

            case POST:
                var json =
                    Url.Decode(
                        request.PostData?.Elements
                        .FirstOrDefault( x => x.Type == PostDataElementType.Bytes )
                        ?.GetBody()
                        ?? string.Empty
                        , true );

                AppHelper.MainWindow!.Invoke( () => {
                    MessageBox.Show( json, "POST Data" );
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
