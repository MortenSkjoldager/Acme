using System;
using System.Web.Http;
using Acme.BusinessLogic.Services;
using Acme.BusinessLogic.Submissions;

namespace Acme.Api
{
    public class SubmissionController : ApiController
    {
        private readonly ISubmissionService _submissionService;

        public SubmissionController(ISubmissionService submissionService)
        {
            _submissionService = submissionService;
        }

        [System.Web.Http.HttpGet]
        [Route("api/submission/validateSubmissionKey/{serialNumber}")]
        public IHttpActionResult ValidateSubmissionKey([FromUri] Guid serialNumber)
        {
            return Json(new
            {
                ActivationCount = _submissionService.GetActivationCount(serialNumber)
            });
        }
    }
}