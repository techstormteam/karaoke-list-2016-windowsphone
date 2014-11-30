using Karaoke_List_2016.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Utility;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Karaoke_List_2016
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static string homeUrl = "http://m.masokaraoke.net/";
        //private static string signinUrl = "http://m.youtube.com/signin";
        //private static string mySubscriptionUrl = "http://m.youtube.com/feed/subscriptions";
        //private static string historyUrl = "http://m.youtube.com/feed/subscriptions";
        //private static string seeFollowingUrl = "http://m.youtube.com/playlist?list=WL";
        //private static string inboxUrl = "http://m.youtube.com/inbox";

        private WebBrowserHelper wbBackKeyPress = new WebBrowserHelper();

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.

            base.OnNavigatedTo(e);
            string appTitle = SystemHelper.GetAppTitle();
            SystemHelper.AskForReview(appTitle);
            Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        private async void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            progressBar.Visibility = Visibility.Visible;
            //base.OnBackKeyPress(e);
            wbBackKeyPress.BackKeyPress(webBrowser, e);
            progressBar.Visibility = Visibility.Collapsed;
            if (e.Handled)
            {
                return;
            }

            string caption = "Thoát";
            string appTitle = SystemHelper.GetAppTitle();
            string message = "Bạn muốn thoát khỏi " + appTitle + "?";
            MessageDialog msgDialog = new MessageDialog(message, caption);

            //OK Button
            UICommand okBtn = new UICommand("OK");
            okBtn.Invoked = (s) =>
            {
                e.Handled = false;
            };
            msgDialog.Commands.Add(okBtn);

            //Cancel Button
            UICommand cancelBtn = new UICommand("Cancel");
            cancelBtn.Invoked = (s) => { e.Handled = true; };
            msgDialog.Commands.Add(cancelBtn);

            await msgDialog.ShowAsync();
        }

        private void backPress() {

        }

        public void GotoPage(Type pageName)
        {
            Frame.Navigate(pageName);
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            progressBar.Visibility = Visibility.Visible;
            object obj = new object();
            //HardwareButtons_BackPressed(obj, new Windows.Phone.UI.Input.BackPressedEventArgs());
            progressBar.Visibility = Visibility.Collapsed;
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            progressBar.Visibility = Visibility.Visible;
            webBrowser.Navigate(new Uri(homeUrl, UriKind.Absolute));
            progressBar.Visibility = Visibility.Collapsed;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            progressBar.Visibility = Visibility.Visible;
            webBrowser.Navigate(webBrowser.Source);
            progressBar.Visibility = Visibility.Collapsed;
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            progressBar.Visibility = Visibility.Visible;
            wbBackKeyPress.Forward(webBrowser);
            progressBar.Visibility = Visibility.Collapsed;
        }

        private void btnRating_Click(object sender, EventArgs e)
        {
            SystemHelper.RateAndReview();
        }

        private void btnUpdateVersion_Click(object sender, EventArgs e)
        {
            SystemHelper.UpdateVersion();
        }

        private void btnShare_Click(object sender, EventArgs e)
        {

        }

        private void btnAboutUs_Click(object sender, EventArgs e)
        {
            GotoPage(typeof(PageAboutUs));
        }


        //private void btnSignin_Click(object sender, EventArgs e)
        //{
        //    webBrowser.Navigate(new Uri(signinUrl, UriKind.Absolute));
        //}

        //private void btnSubscription_Click(object sender, EventArgs e)
        //{
        //    webBrowser.Navigate(new Uri(mySubscriptionUrl, UriKind.Absolute));
        //}

        //private void btnHistory_Click(object sender, EventArgs e)
        //{
        //    webBrowser.Navigate(new Uri(historyUrl, UriKind.Absolute));
        //}

        //private void btnSeeFollowing_Click(object sender, EventArgs e)
        //{
        //    webBrowser.Navigate(new Uri(seeFollowingUrl, UriKind.Absolute));
        //}

        //private void btnInbox_Click(object sender, EventArgs e)
        //{
        //    webBrowser.Navigate(new Uri(inboxUrl, UriKind.Absolute));
        //}

        private void WebBrowser_Navigated(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            progressBar.Visibility = Visibility.Visible;
            wbBackKeyPress.Navigated(args);
            progressBar.Visibility = Visibility.Collapsed;
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //// Switch the placement of the buttons based on an orientation change.
            //if ((e.Orientation & PageOrientation.Portrait) == (PageOrientation.Portrait))
            //{
            //    Grid.SetRow(webBrowser, 1);
            //    Grid.SetColumn(webBrowser, 0);
            //}
            //// If not in portrait, move buttonList content to visible row and column.
            //else
            //{
            //    Grid.SetRow(webBrowser, 0);
            //    Grid.SetColumn(webBrowser, 1);
            //}
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (App.NeedShowAd)
            {
                //InneractiveAdHelper.DisplayInterstitial(LayoutRoot);
                App.NeedShowAd = false;
            }
            webBrowser.Navigate(new Uri(homeUrl, UriKind.Absolute));
        }
    }
}
