using System;
using System.Collections.Generic;
using System.Text;

using Windows.UI.Notifications;
using NotificationsExtensions.TileContent;
using Windows.Data.Xml.Dom;

namespace BunnyEscape.Handlers
{
    public class NotificationHandler
    {
        public void CreateNotification(string title, string text1 = "", string text2 = "", string text3 = "")
        {
            ITileSquare150x150Text01 tileContent = TileContentFactory.CreateTileSquare150x150Text01();

            tileContent.TextHeading.Text = title;
            tileContent.TextBody1.Text = text1;
            tileContent.TextBody2.Text = text2;
            tileContent.TextBody3.Text = text3;

            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileContent.CreateNotification());
        }

        public void SimpleNotification(string string1, string string2 = "")
        {
            // simple example with a Toast, to enable this go to manifest file
            // and mark App as TastCapable - it won't work without this
            // The Task will start but there will be no Toast.
            ToastTemplateType toastTemplate = ToastTemplateType.ToastText02;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            XmlNodeList textElements = toastXml.GetElementsByTagName("text");
            textElements[0].AppendChild(toastXml.CreateTextNode(string1));
            textElements[1].AppendChild(toastXml.CreateTextNode(string2));
            ToastNotificationManager.CreateToastNotifier().Show(new ToastNotification(toastXml));
        }
    }
}
