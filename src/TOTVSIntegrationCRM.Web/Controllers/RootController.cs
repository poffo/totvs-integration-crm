using Microsoft.AspNetCore.Mvc;

namespace TOTVSIntegrationCRM.Web.Controllers
{
    [Route("/")]
    public class RootController : TnfController
    {
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult Get()
        {           
            return CreateResponseOnGet("Running");
        }       
    }
}
