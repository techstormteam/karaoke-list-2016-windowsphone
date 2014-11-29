using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Utility;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Karaoke_List_2016.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PageAboutUs : Page
    {
        public PageAboutUs()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void lblUpdateVersion_Tap(object sender, TappedRoutedEventArgs e)
        {
            SystemHelper.UpdateVersion();
        }

        private void lblMyLink_Tap(object sender, TappedRoutedEventArgs e)
        {
            SystemHelper.OpenLink("http://techstorm-solution.com/");
        }

        private void lblMyTeam_Tap(object sender, TappedRoutedEventArgs e)
        {
            SystemHelper.OpenLink("http://techstorm-solution.com/");
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            lblMyTeam.Text = SystemHelper.GetAppAuthor();
        }

        private void lblRating_Tap(object sender, TappedRoutedEventArgs e)
        {
            SystemHelper.RateAndReview();
        }
    }
}
