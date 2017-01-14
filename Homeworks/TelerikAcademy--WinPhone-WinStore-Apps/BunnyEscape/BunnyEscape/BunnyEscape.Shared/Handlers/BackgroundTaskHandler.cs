using System;
using System.Collections.Generic;
using System.Text;
using Windows.ApplicationModel.Background;

namespace BunnyEscape.Handlers
{
    public class BackgroundTaskHandler
    {
        public const string MusicTaskName = "BackgroundMusicPlayer";
        public const string MusicTaskEntryPoint = "BackgroundTasks.BackgroundMusicPlayer";
        public const string NotificatorTaskName = "BackgroundNotificationHandler";
        public const string NotificatorTaskEntryPoint = "BackgroundTasks.BackgroundNotificationHandler";

        public async void StartTask(string myTaskName, string taskEntryPoint)
        {
            // check if task is already registered
            foreach (var cur in BackgroundTaskRegistration.AllTasks)
            {
                if (cur.Value.Name == myTaskName)
                {
                    return;
                }
            }

            // Windows Phone app must call this to use trigger types (see MSDN)
            await BackgroundExecutionManager.RequestAccessAsync();

            // register a new task
            BackgroundTaskBuilder taskBuilder = new BackgroundTaskBuilder { Name = myTaskName, TaskEntryPoint = taskEntryPoint };
            taskBuilder.SetTrigger(new TimeTrigger(15, true));
            BackgroundTaskRegistration myFirstTask = taskBuilder.Register();
        }

    }
}
