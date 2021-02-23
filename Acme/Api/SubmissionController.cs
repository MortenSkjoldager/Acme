using System;
using System.Web.Http;
using Acme.BusinessLogic.Services;
using Acme.BusinessLogic.Submissions;
using Acme.Model;

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

        [System.Web.Http.HttpPost]
        [Route("api/submissions/create")]
        public IHttpActionResult Create(SubmissionRequestModel model)
        {
            return Json(_submissionService.CreateSubmission(model.FirstName, model.LastName, model.Email, model.Age, model.SerialNumber));
        }

        [System.Web.Http.HttpGet]
        [Route("api/submissions/get/{skip}/{take}")]
        public IHttpActionResult GetSubmissions(int skip, int take)
        {
            return Json(_submissionService.GetSubmissions(skip, take));
        }
    }
}