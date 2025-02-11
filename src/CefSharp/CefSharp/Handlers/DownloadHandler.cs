﻿using System;

namespace CefSharp.Handlers
{
    public class DownloadHandler : IDownloadHandler
    {

        public event EventHandler<DownloadItem> OnBeforeDownloadFired;

        public event EventHandler<DownloadItem> OnDownloadUpdatedFired;

        public void OnBeforeDownload(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
        {
            if (OnBeforeDownloadFired != null)
                OnBeforeDownloadFired.Invoke(this, downloadItem);

            if (!callback.IsDisposed)
            {
                using (callback)
                {
                    callback.Continue(downloadItem.SuggestedFileName, showDialog: true);
                }
            }
        }


        public void OnDownloadUpdated(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
        {
            if (OnDownloadUpdatedFired != null)
                OnDownloadUpdatedFired.Invoke(this, downloadItem);
        }

    }
}
