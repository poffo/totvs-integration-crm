using Microsoft.AspNetCore.Mvc;

namespace TOTVSIntegrationCRM.Web.Controllers
{
    [Route("/statusz")]
    public class StatusZController : TnfController
    {
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult Get()
        {           
            return CreateResponseOnGet("ok");
        }       
    }
}
