using BunnyEscape.Models;
using Parse;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telerik.Everlive.Sdk.Core;
using Telerik.Everlive.Sdk.Core.Query.Definition.Sorting;

namespace BunnyEscape.Handlers
{
    public class GlobalScoreHandler
    {

        private static GlobalScoreHandler Instance;
        public static GlobalScoreHandler GetInstance()
        {
            if (Instance == null)
            {
                Instance = new GlobalScoreHandler();
            }
            return Instance;
        }

        private EverliveApp app;
        private GlobalScoreHandler()
        {
            this.app = new EverliveApp("Y2NaFylY3prKvnhn");
        }


        public async Task SaveNewScore(IScore score)
        {
            var sc = score as ScoreGlobal;
            if (sc == null)
            {
                return;
            }

            await this.app.WorkWith().Data<ScoreGlobal>().Create(sc).ExecuteAsync();
            return;
        }

        public async Task<IEnumerable<IScore>> GetTopScores(int count = 10)
        {
            SortingDefinition sortAsc = new SortingDefinition("Points", Telerik.Everlive.Sdk.Core.Linq.Translators.OrderByDirection.Descending);
            var scores = await this.app.WorkWith()
                                   .Data<ScoreGlobal>()
                                   .Get()
                                   .SetSorting(sortAsc)
                                   .Take(count)
                                   .ExecuteAsync();
            return scores;
        }
    }
}
