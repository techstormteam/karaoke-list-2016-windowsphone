using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using Windows.UI.Popups;

namespace Utility
{
    public class VersionUpdateHelper
    {
        public static void CheckForUpdatedVersion()
        {
            //var currentVersion = new Version(GetManifestAttributeValue("Version"));
            //var updatedVersion = await GetUpdatedVersion();

            //MessageDialog msgDialog = new MessageDialog("Do you want to install the new version now?", "Update Available");
            ////OK Button
            //UICommand okBtn = new UICommand("OK");
            //okBtn.Invoked = (s) =>
            //{
            //    if (updatedVersion > currentVersion) {
            //        //new MarketplaceDetailTask().Show();
            //        Windows.ApplicationModel.Store.CurrentApp.RequestAppPurchaseAsync(false);
            //    }
            //};
            //msgDialog.Commands.Add(okBtn);

            ////Cancel Button
            //UICommand cancelBtn = new UICommand("Cancel");
            //msgDialog.Commands.Add(cancelBtn);
        }

        public static string GetManifestAttributeValue(string attributeName)
        {
            //var xmlReaderSettings = new XmlReaderSettings
            //{
            //    XmlResolver = new XmlXapResolver()
            //};

            //using (var xmlReader = XmlReader.Create("WMAppManifest.xml", xmlReaderSettings))
            //{
            //    xmlReader.ReadToDescendant("App");

            //    return xmlReader.GetAttribute(attributeName);
            //}
            return "";
        }

        //private static Task<Version> GetUpdatedVersion()
        //{
            //var cultureInfoName = CultureInfo.CurrentUICulture.Name;

            //var url = string.Format("http://marketplaceedgeservice.windowsphone.com/v8/catalog/apps/{0}?os={1}&cc={2}&oc=&lang={3}​",
            //    GetManifestAttributeValue("ProductID"),
            //    Environment.OSVersion.Version,
            //    cultureInfoName.Substring(cultureInfoName.Length - 2).ToUpperInvariant(),
            //    cultureInfoName);

            //var request = WebRequest.Create(url);

            //return Task.Factory.FromAsync(request.BeginGetResponse, result =>
            //{
            //    var response = (HttpWebResponse)request.EndGetResponse(result);

            //    if (response.StatusCode != HttpStatusCode.OK)
            //    {
            //        throw new WebException("Http Error: " + response.StatusCode);
            //    }

            //    using (var outputStream = response.GetResponseStream())
            //    {
            //        using (var reader = XmlReader.Create(outputStream))
            //        {
            //            reader.MoveToContent();

            //            var aNamespace = reader.LookupNamespace("a");

            //            reader.ReadToFollowing("entry", aNamespace);

            //            reader.ReadToDescendant("version");

            //            return new Version(reader.ReadElementContentAsString());
            //        }
            //    }
            //}, null);

        //}
    }
}
