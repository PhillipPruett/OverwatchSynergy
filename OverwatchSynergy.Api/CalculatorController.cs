using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OverwatchSynergy.Api
{
    [RoutePrefix("calculator")]
    public class CalculatorController : ApiController
    {
        [HttpPost, Route("GetHeroesThatHaveSynergiesWith")]
        public IEnumerable<Weight> GetHeroesThatHaveSynergiesWith(string[] team)
        {
            var synergies = Calculator.GetSynergies(Calculator.Heroes.Where(h => team.Contains(h.Name)));
            return synergies;
        }

        [HttpPost, Route("GetHeroesStrengthAgainst")]
        public IEnumerable<Weight> GetHeroesStrengthAgainst(string[] enemyTeam)
        {
            var synergies = Calculator.GetHeroesStrengthAgainst(Calculator.Heroes.Where(h => enemyTeam.Contains(h.Name)));
            return synergies;
        }

        [HttpPost, Route("GetOverallRankingsForAllHeroes")]
        public IEnumerable<Weight> GetOverallScoresForAllHeroes(GetOverallRankingsForAllHeroesRequest request)
        {
            var scores = Calculator.GetOverallScoresForAllHeroes(Calculator.Heroes.Where(h => request.Opponents.Contains(h.Name)),
                                                                 Calculator.Heroes.Where(h => request.Teammates.Contains(h.Name)),
                                                                 request.RelativeSynergyWeight);
            return scores;
        }
    }

    public class GetOverallRankingsForAllHeroesRequest
    {
        public IEnumerable<string> Opponents { get; set; }
        public IEnumerable<string> Teammates { get; set; }
        public double RelativeSynergyWeight { get; set; } = 1;
    }
}