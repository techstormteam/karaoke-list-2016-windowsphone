using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Windows.System;
using Windows.UI.Popups;

namespace Utility
{
    public class SystemHelper
    {
        public static void CountForReview(int numStartToAsk)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["askforreview"] = false;

            int started = 0;
            if (localSettings.Values.ContainsKey("started"))
            {
                started = (int)localSettings.Values["started"];
            }
            started++;
            localSettings.Values["started"] = started;

            bool reviewed = false;
            if (localSettings.Values.ContainsKey("reviewed"))
            {
                reviewed = (bool)localSettings.Values["reviewed"];
            }

            if (reviewed == false && started >= numStartToAsk)
            {
                localSettings.Values["askforreview"] = true;
            }
        }

        public static void AskForReview(string appName)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            var askforReview = (bool)localSettings.Values["askforreview"];
            if (askforReview)
            {
                //make sure we only ask once! 
                localSettings.Values["askforreview"] = false;

                MessageDialog msgDialog = new MessageDialog(string.Format("Cảm ơn bạn đã sử dụng {0}, Hãy đánh giá 5 sao cho ứng dụng và comment chức năng mà bạn muốn ở phiên bản kế tiếp.", appName), 
                    "Hãy đánh giá 5 sao!");
                
                //OK Button
                UICommand okBtn = new UICommand("OK");
                okBtn.Invoked = (s) =>
                {
                    localSettings.Values["reviewed"] = true;
                    //var marketplaceReviewTask = new MarketplaceReviewTask();
                    //marketplaceReviewTask.Show();
                    Windows.ApplicationModel.Store.CurrentApp.RequestAppPurchaseAsync(false);
                };
                msgDialog.Commands.Add(okBtn);

                //Cancel Button
                UICommand cancelBtn = new UICommand("Cancel");
                msgDialog.Commands.Add(cancelBtn);

            }
        }

        public static string GetAppID()
        {
            string appID = (from manifest in
                                System.Xml.Linq.XElement.Load("WMAppManifest.xml").Descendants("App")
                            select
                            manifest).SingleOrDefault().Attribute("ProductID").Value;
            return appID;
        }

        public static string GetAppTitle()
        {
            string appTitle = (from manifest in
                                System.Xml.Linq.XElement.Load("WMAppManifest.xml").Descendants("App")
                            select
                            manifest).SingleOrDefault().Attribute("Title").Value;
            return appTitle;
        }

        public static string GetAppAuthor()
        {
            string appAuthor = (from manifest in
                                System.Xml.Linq.XElement.Load("WMAppManifest.xml").Descendants("App")
                            select
                            manifest).SingleOrDefault().Attribute("Author").Value;
            return appAuthor;
        }

        public async static void UpdateVersion()
        {
            //MarketplaceDetailTask marketplaceDetailTask = new MarketplaceDetailTask();
            //marketplaceDetailTask.ContentIdentifier = SystemHelper.GetAppID();
            //marketplaceDetailTask.ContentType = MarketplaceContentType.Applications;
            //marketplaceDetailTask.Show();

            await Windows.ApplicationModel.Store.CurrentApp.RequestAppPurchaseAsync(false);
        }

        public async static void OpenLink(string link)
        {
            await Launcher.LaunchUriAsync(new Uri(link));
        }
        public static void RateAndReview()
        {
            String appId = GetAppID();
            OpenLink("ms-windows-store:reviewapp?appid=" + appId);
        }

        public static void ShareLink(string link)
        {
            //ShareLinkTask shareLinkTask = new ShareLinkTask()
            //{
            //    Title = "Great App! Join it now :)",
            //    LinkUri = new Uri("http://msdn.microsoft.com/en-us/library/windowsphone/develop/ff431744(v=vs.92).aspx", UriKind.Absolute),
            //    Message = "Hello, I would like to share you a great app that I used and loved.\n" + link
            //};

            //shareLinkTask.Show();
        }


        public static void ShareEmail(string link)
        {
            //EmailComposeTask emailComposeTask = new EmailComposeTask()
            //{
            //    Subject = "Great App! Join it now :)",
            //    Body = "Hello, I would like to share you a great app that I used and loved.\n" + link,
            //    To = "recipient@example.com",
            //    Cc = "",
            //    Bcc = ""
            //};

            //emailComposeTask.Show();
        }

        public static void ShareSMS(string link)
        {
            //SmsComposeTask smsComposeTask = new SmsComposeTask()
            //{
            //    Body = "Try this new application. It's great!" + link
            //};

            //smsComposeTask.Show();
        }

        public static bool ShowExitMessageBox(string appName)
        {
            string caption = "Thoát";
            string message = string.Format("Bạn muốn thoát khỏi {0}?", appName);
            MessageDialog msgDialog = new MessageDialog(message, caption);
            bool cancel = false;
            //OK Button
            UICommand okBtn = new UICommand("OK");
            okBtn.Invoked = (s) =>
            {
                cancel = true;
            };
            msgDialog.Commands.Add(okBtn);

            //Cancel Button
            UICommand cancelBtn = new UICommand("Cancel");
            msgDialog.Commands.Add(cancelBtn);
            return cancel;
        }

    }
}
