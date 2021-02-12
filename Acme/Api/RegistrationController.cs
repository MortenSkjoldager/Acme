using System.Web.Http;
using Acme.BusinessLogic.Services;

namespace Acme.Api
{
    public class RegistrationController : ApiController
    {
        private readonly ISerialNumberService _serialNumberService;

        public RegistrationController(ISerialNumberService serialNumberService)
        {
            _serialNumberService = serialNumberService;
        }
        
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetForm()
        {
            return Json(
            new {
                Title = "Hello World"
            });
        }
    }
}