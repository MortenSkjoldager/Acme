using System;
using System.Web.Http;
using Acme.BusinessLogic.Services;

namespace Acme.Api
{
    public class SerialNumberController : ApiController
    {
        private readonly ISerialNumberService _serialNumberService;

        public SerialNumberController(ISerialNumberService serialNumberService)
        {
            _serialNumberService = serialNumberService;
        }
        
        [System.Web.Http.HttpGet]
        [Route("api/serialnumber/validate/{serialNumber}")]
        public IHttpActionResult Validate([FromUri]Guid serialNumber)
        {
            return Json(new
            {
                valid = _serialNumberService.ValidateSerialNumber(serialNumber),
            });
        }
    }
}