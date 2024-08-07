using CefSharp;

namespace GenericBrowser;

public class EmptyResourceHandler : ResourceHandler
{
    public override CefReturnValue ProcessRequestAsync(
        IRequest request,
        ICallback callback )
        => CefReturnValue.Continue;
}
