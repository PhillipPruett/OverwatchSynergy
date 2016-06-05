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

        [HttpPost, Route("GetHeroesThatAreWeakAgainst")]
        public IEnumerable<Weight> GetHeroesThatAreWeakAgainst(string[] enemyTeam)
        {
            var synergies = Calculator.GetHeroesThatAreWeakAgainst(Calculator.Heroes.Where(h => enemyTeam.Contains(h.Name)));
            return synergies;
        }
    }
}