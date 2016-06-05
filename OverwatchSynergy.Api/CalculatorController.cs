using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OverwatchSynergy.Api
{
    [RoutePrefix("calculator")]
    public class CalculatorController : ApiController
    {
        [HttpPost, Route("")]
        public IEnumerable<Weight> GetSynergies(string[] team)
        {
            var synergies = Calculator.GetSynergies(Calculator.Heroes.Where(h => team.Contains(h.Name)));
            return synergies;
        }
    }
}