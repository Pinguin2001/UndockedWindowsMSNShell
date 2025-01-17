using System;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using muxc = Microsoft.UI.Xaml.Controls;

namespace Feeds
{
    public sealed partial class MainPage : Page
    {
        public MainPage() => InitializeComponent();

        private void WebView2Control_CoreWebView2Initialized(muxc.WebView2 sender, muxc.CoreWebView2InitializedEventArgs args)
        {
            sender.CoreWebView2.Settings.IsStatusBarEnabled = false;
            sender.CoreWebView2.Settings.IsSwipeNavigationEnabled = false;
            sender.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            sender.CoreWebView2.Settings.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; Cortana 1.14.4.19041; 10.0.0.0.19045.5371) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.102 Safari/537.36 Edge/18.19045";
            sender.NavigationStarting += WebView2Control_NavigationStarting;
            sender.NavigationCompleted += WebView2Control_NavigationCompleted;
            sender.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;
        }

        private void WebView2Control_NavigationStarting(muxc.WebView2 sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs args)
        {
            ProgressRing.Visibility = Visibility.Visible;
        }

        private void WebView2Control_NavigationCompleted(muxc.WebView2 sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs args)
        {
            ProgressRing.Visibility = Visibility.Collapsed;
        }

        private async void CoreWebView2_NewWindowRequested(Microsoft.Web.WebView2.Core.CoreWebView2 sender, Microsoft.Web.WebView2.Core.CoreWebView2NewWindowRequestedEventArgs args)
        {
            string url = args.Uri;
            await Launcher.LaunchUriAsync(new Uri(url));
            args.Handled = true;
        }
    }
}
