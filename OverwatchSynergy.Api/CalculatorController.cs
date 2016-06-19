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
            var enemyTeam = request.Opponents.Select(o => Calculator.Heroes.Single(h => h.Name == o));
            var team = request.Teammates.Select(t => Calculator.Heroes.Single(h => h.Name == t));
            var objectiveType = Calculator.ObjectiveTypes.Single(o => o.Id == request.ObjectiveGameType);

            var scores = Calculator.GetOverallScoresForAllHeroes(enemyTeam, team, objectiveType);
            return scores;
        }
    }

    public class GetOverallRankingsForAllHeroesRequest
    {
        public IEnumerable<string> Opponents { get; set; }
        public IEnumerable<string> Teammates { get; set; }
        public string ObjectiveGameType { get; set; }
    }
}