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
            return new[]
                   {
                       new Hero {Name = "Genji", Role = "Attack"},
                       new Hero {Name = "McCree", Role = "Attack"},
                       new Hero {Name = "Pharah", Role = "Attack"},
                       new Hero {Name = "Reaper", Role = "Attack"},
                       new Hero {Name = "Soldier: 76", Role = "Attack"},
                       new Hero {Name = "Tracer", Role = "Attack"},
                       new Hero {Name = "Bastion", Role = "Defense"},
                       new Hero {Name = "Hanzo", Role = "Defense"},
                       new Hero {Name = "Junkrat", Role = "Defense"},
                       new Hero {Name = "Mei", Role = "Defense"},
                       new Hero {Name = "Torbjörn", Role = "Defense"},
                       new Hero {Name = "Widowmaker", Role = "Defense"},
                       new Hero {Name = "D.Va", Role = "Tank"},
                       new Hero {Name = "Reinhardt", Role = "Tank"},
                       new Hero {Name = "Roadhog", Role = "Tank"},
                       new Hero {Name = "Winston", Role = "Tank"},
                       new Hero {Name = "Zarya", Role = "Tank"},
                       new Hero {Name = "Lúcio", Role = "Support"},
                       new Hero {Name = "Mercy", Role = "Support"},
                       new Hero {Name = "Symmetra", Role = "Support"},
                       new Hero {Name = "Zenyatta", Role = "Support"},
                   };
        }
    }
}
