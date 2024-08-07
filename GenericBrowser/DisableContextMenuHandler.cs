﻿using CefSharp;

namespace GenericBrowser;

public class DisableContextMenuHandler : IContextMenuHandler
{
    public void OnBeforeContextMenu(
        IWebBrowser chromiumWebBrowser,
        IBrowser browser,
        IFrame frame,
        IContextMenuParams parameters,
        IMenuModel model )
        => model.Clear();

    public bool OnContextMenuCommand(
        IWebBrowser chromiumWebBrowser,
        IBrowser browser,
        IFrame frame,
        IContextMenuParams parameters,
        CefMenuCommand commandId,
        CefEventFlags eventFlags )
        => false;

    public void OnContextMenuDismissed(
        IWebBrowser chromiumWebBrowser,
        IBrowser browser,
        IFrame frame )
    { }

    public bool RunContextMenu(
        IWebBrowser chromiumWebBrowser,
        IBrowser browser,
        IFrame frame,
        IContextMenuParams parameters,
        IMenuModel model,
        IRunContextMenuCallback callback )
        => false;
}
