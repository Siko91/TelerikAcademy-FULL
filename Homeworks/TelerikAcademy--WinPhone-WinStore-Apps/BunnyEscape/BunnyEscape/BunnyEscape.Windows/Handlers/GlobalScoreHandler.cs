using BunnyEscape.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telerik.Everlive.Sdk.Core;
using Telerik.Everlive.Sdk.Core.Model.Result;
using Telerik.Everlive.Sdk.Core.Query.Definition.Sorting;

namespace BunnyEscape.Handlers
{
    public class GlobalScoreHandler
    {
        private IEnumerable<IScore> scores;
        private EverliveApp app;

        private static GlobalScoreHandler Instance;

        public static GlobalScoreHandler GetInstance()
        {
            if (Instance == null)
            {
                Instance = new GlobalScoreHandler();
            }
            return Instance;
        }

        private GlobalScoreHandler()
        {
            this.app = new EverliveApp("Y2NaFylY3prKvnhn");

            SortingDefinition sortAsc = new SortingDefinition("Points", Telerik.Everlive.Sdk.Core.Linq.Translators.OrderByDirection.Descending);
            app.WorkWith().Data<ScoreGlobal>().Get()
                .SetSorting(sortAsc)
                .Take(10)
                .Execute(OnGetItemsExecuted);
        }

        private void OnGetItemsExecuted(IEnumerable<ScoreGlobal> obj)
        {
            this.scores = obj;
        }


        public async Task SaveNewScore(IScore score)
        {
            var sc = score as ScoreGlobal;
            if (sc == null)
            {
                return;
            }

            app.WorkWith().Data<ScoreGlobal>().Create(sc).Execute(OnSend);
            return;
        }
 
        private void OnSend(CreateResultItem obj)
        {
        }

        public async Task<IEnumerable<IScore>> GetTopScores(int count = 10)
        {
            IEnumerable<IScore> results = scores;
            return results;
        }
    }
}
