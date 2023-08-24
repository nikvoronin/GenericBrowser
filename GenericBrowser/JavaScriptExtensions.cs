using CefSharp;

namespace GenericBrowser
{
    public static class JavaScriptExtensions
    {
        public static bool Failed( this JavascriptResponse r )
            => r is null || !r.Success;
    }
}
