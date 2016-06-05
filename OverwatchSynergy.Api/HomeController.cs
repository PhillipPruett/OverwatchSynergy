using System;
using System.Web.Http;
using System.Web.Http.Results;

namespace OverwatchSynergy.Api
{
    public class HomeController : ApiController
    {
        [HttpGet, Route("")]
        public RedirectResult Get()
        {
            return Redirect(new Uri("wwwroot/", UriKind.Relative));
        }
    }
}