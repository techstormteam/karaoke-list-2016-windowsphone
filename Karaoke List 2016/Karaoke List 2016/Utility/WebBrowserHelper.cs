﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.UI.Xaml.Controls;

namespace Utility
{
    public class WebBrowserHelper
    {
        Stack<Uri> history = new Stack<Uri>();
        Stack<Uri> forward = new Stack<Uri>();
        Uri current = null;
        bool isPerformingCloseOperation = false;

        public void Navigated(WebViewNavigationCompletedEventArgs e)
        {
            Uri previous = null;
            if (history.Count > 0) {
                previous = history.Peek();
            }

            if (previous != null)
            {
                if (e.Uri.AbsoluteUri != previous.AbsoluteUri)
                {
                    history.Push(e.Uri);
                }
            }
            else
            {
                history.Push(e.Uri);
            }
            current = e.Uri;
        }

        public void BackKeyPress(WebView webBrowser, System.ComponentModel.CancelEventArgs e)
        {
            if (!isPerformingCloseOperation)
            {
                if (history.Count > 0)
                {
                    Uri destination = null;
                    Uri forwardUri = history.Pop();
                    if (history.Count > 0)
                    {
                        destination = history.Peek();
                        webBrowser.Navigate(destination);
                    }
                    // What about using script and going history.back? 
                    // you can do it, but 
                    // I rather use that to keep ‘track’ consistently with our stack 
                    e.Cancel = true;

                    if (forwardUri != null)
                    {
                        forward.Push(forwardUri);
                    }
                }
            }
        }

        public void Forward(WebView webBrowser)
        {
            if (!isPerformingCloseOperation)
            {
                if (forward.Count > 0)
                {
                    Uri destination = forward.Pop();
                    webBrowser.Navigate(destination);

                    if (destination != null)
                    {
                        history.Push(destination);
                    }
                }
            }
        }

    }
}
