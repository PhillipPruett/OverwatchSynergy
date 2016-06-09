using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OverwatchSynergy.Api
{
    [RoutePrefix("calculator")]
    public class CalculatorController : ApiController
    {
        [HttpPost, Route("GetOverallScoresForAllHeroes")]
        public IEnumerable<Weight> GetOverallScoresForAllHeroes(GetOverallRankingsForAllHeroesRequest request)
        {
            var scores = Calculator.GetOverallScoresForAllHeroes(Calculator.Heroes.Where(h => request.Opponents.Contains(h.Name)),
                                                                 Calculator.Heroes.Where(h => request.Teammates.Contains(h.Name)),
                                                                 request.ObjectiveGameType);
            return scores;
        }
    }

    public class GetOverallRankingsForAllHeroesRequest
    {
        public IEnumerable<string> Opponents { get; set; }
        public IEnumerable<string> Teammates { get; set; }
        public ObjectiveType ObjectiveGameType { get; set; }
    }
}