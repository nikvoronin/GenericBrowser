using CefSharp;
using Flurl;
using System.Linq;
using System.Windows;

namespace GenericBrowser;

public class BroSchemaHandlerFactory : ISchemeHandlerFactory
{
    public IResourceHandler Create(
        IBrowser browser, IFrame frame, string schemaName, IRequest request )
    {
        var u = Url.Parse( request.Url );
        var schemaMismatch =
            schemaName != SchemaName
            || u.Scheme != schemaName;

        if (schemaMismatch) return new ResourceHandler();

        switch (request.Method.ToUpper()) {
        case GET:
            MessageBox.Show( request.Url, GET );
            break;

        case POST:
            var json =
                Url.Decode(
                    request.PostData?.Elements
                    .FirstOrDefault( x => x.Type == PostDataElementType.Bytes )
                    ?.GetBody()
                    ?? string.Empty,
                    true );

            MessageBox.Show( json, POST );
            break;
        }

        return
            new EmptyResourceHandler(); // just OK 200
    }

    public const string SchemaName = "bro";
    private const string GET = "GET";
    private const string POST = "POST";
}
