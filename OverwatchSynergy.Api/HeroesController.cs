using System.Collections.Generic;
using System.Collections.Generic;
using System.Web.Http;
using OverwatchSynergy.Api.Heroes;

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
