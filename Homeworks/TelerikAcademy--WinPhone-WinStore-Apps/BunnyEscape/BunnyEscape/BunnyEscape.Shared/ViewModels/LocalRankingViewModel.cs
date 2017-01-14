using BunnyEscape.Handlers;
using BunnyEscape.Models;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BunnyEscape.ViewModels
{
    public class LocalRankingViewModel : ViewModelBase, IScoreViewModel
    {
        private SQLiteScoreHandler ScoresHandler;
        private ICollection<IScore> scores = new List<IScore>();

        public LocalRankingViewModel()
        {
            this.ScoresHandler = SQLiteScoreHandler.CreateInstance();
            LoadScoresAsync();
        }

        private async Task LoadScoresAsync()
        {
 	        this.Scores = await ScoresHandler.GetTopScores();
        }

        public IEnumerable<IScore> Scores
        {
            get
            {
                return this.scores;
            }
            set
            {
                this.scores.Clear();
                foreach (var sc in value)
                {
                    this.scores.Add(sc);
                }
                this.RaisePropertyChanged("Scores");
            }
        }


        public string Title { get { return "Local Highscores"; } }
        public string BackgroundImagePath
        {
            get { return @"Resourses\Real\background.gif"; }
        }


        public double WidthOfColumn
        {
            get { return 0.2; }
        }
    }
}
