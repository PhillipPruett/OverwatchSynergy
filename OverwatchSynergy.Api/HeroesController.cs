using System.Collections.Generic;
using System.Web.Http;

namespace OverwatchSynergy.Api
{
    [RoutePrefix("heroes")]
    public class HeroesController : ApiController
    {
        [HttpGet, Route("")]
        public IEnumerable<Hero> Get()
        {
            return Calculator.Heroes;
        }
    }
}
