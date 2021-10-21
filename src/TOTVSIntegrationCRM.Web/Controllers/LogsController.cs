using Microsoft.AspNetCore.Mvc;

namespace TOTVSIntegrationCRM.Web.Controllers
{
    [Route("/logs")]
    public class LogsController : TnfController
    {
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult Get()
        {           
            return CreateResponseOnGet("ok");
        }       
    }
}
