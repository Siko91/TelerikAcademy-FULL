using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotificationsExtensions.TileContent;
using Windows.ApplicationModel.Background;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;

namespace BackgroundTasks
{
    public sealed class BackgroundNotificationHandler : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            this.CreateNotification(
                "<< BunnyEscape >>",
                "Congratulations!",
                "Points scored",
                "Keep it up!");

            this.SimpleNotification("Bunny escape is awesome", "Share it with your friends to compete with them.");
        }
        public void CreateNotification(string title, string text1, string text2, string text3)
        {
            ITileSquare150x150Text01 tileContent = TileContentFactory.CreateTileSquare150x150Text01();

            tileContent.TextHeading.Text = title;
            tileContent.TextBody1.Text = text1;
            tileContent.TextBody2.Text = text2;
            tileContent.TextBody3.Text = text3;

            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileContent.CreateNotification());
        }

        public void SimpleNotification(string string1, string string2)
        {
            ToastTemplateType toastTemplate = ToastTemplateType.ToastText02;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);
            XmlNodeList textElements = toastXml.GetElementsByTagName("text");
            textElements[0].AppendChild(toastXml.CreateTextNode(string1));
            textElements[1].AppendChild(toastXml.CreateTextNode(string2));
            ToastNotificationManager.CreateToastNotifier().Show(new ToastNotification(toastXml));
        }
    }
}
