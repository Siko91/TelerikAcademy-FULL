using BunnyEscape.Handlers;
using BunnyEscape.Models;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace BunnyEscape.ViewModels
{
    public class GameOverViewModel : ViewModelBase
    {
        private long score;
        private string playerName = "";
        private bool saveToLocal = true;
        private bool saveToGlobal = true;
        public GameOverViewModel()
        {
            this.globalScoreHandler = GlobalScoreHandler.GetInstance();
            this.localScoreHandler = new SQLiteScoreHandler();
        }

        public string ScoreDescription
        {
            get
            {
                if (this.Score < 500) { return " a tiny amount"; }
                if (this.Score < 1000) { return " a small amount"; }
                if (this.Score < 1500) { return " an average amount"; }
                if (this.Score < 2500) { return " a good amount"; }
                if (this.Score < 5000) { return " a lot"; }
                if (this.Score < 10000) { return " a very big amount"; }
                if (this.Score < 50000) { return " an unbelivable amount"; }
                return " a godlike amount of";
            }
        }
        public long Score
        {
            get
            {
                return this.score;
            }
            set
            {
                this.score = value;
                RaisePropertyChanged("Score");
                RaisePropertyChanged("ScoreDescription");
            }
        }
        public string PlayerName
        {
            get
            {
                return this.playerName;
            }
            set
            {
                this.playerName = value;
                RaisePropertyChanged("PlayerName");
                RaisePropertyChanged("IsReadyToContinue");
            }
        }
        public bool IsReadyToContinue
        {
            get
            {
                return this.PlayerName.Length > 0 || (!SaveToLocal && !SaveToGlobal);
            }
        }
        public bool SaveToLocal
        {
            get
            {
                return this.saveToLocal;
            }
            set
            {
                this.saveToLocal = value;
                RaisePropertyChanged("SaveToLocal");
                RaisePropertyChanged("IsReadyToContinue");
            }
        }
        public bool SaveToGlobal
        {
            get
            {
                return this.saveToGlobal;
            }
            set
            {
                this.saveToGlobal = value;
                RaisePropertyChanged("SaveToGlobal");
                RaisePropertyChanged("IsReadyToContinue");
            }
        }

        public SQLiteScoreHandler localScoreHandler { get; set; }
        public GlobalScoreHandler globalScoreHandler { get; set; }

        public void SaveScoreLocaly()
        {
            ScoreLocal sc = new ScoreLocal(Score, PlayerName);
            localScoreHandler.SaveNewScore(sc);
        }

        public void SaveScoreGlobaly()
        {
            ScoreGlobal sc = new ScoreGlobal(Score, PlayerName);
            globalScoreHandler.SaveNewScore(sc);
        }

        internal void MakeNotification()
        {
            //new BackgroundTaskHandler().StartTask(BackgroundTaskHandler.NotificatorTaskName, BackgroundTaskHandler.NotificatorTaskEntryPoint);
            var notif = new NotificationHandler();
            if (this.Score > 0)
            {
                notif.SimpleNotification("You have scored scored some points on BunnyEscape", this.Score + " (" + this.ScoreDescription + ")");
            }
            else
            {
                notif.SimpleNotification("You played BunnyEscape without scoring anything", "Good luck next time, loser!");
            }
            notif.CreateNotification("BunnyEscape & TurboMode", "Try playing with turbo mode", "Try playing without it", "Find out what fits you best");
        }
    }
}
