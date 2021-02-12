using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Acme.BusinessLogic.Services;

namespace Acme.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISerialNumberService _serialNumberService;

        public HomeController(ISerialNumberService serialNumberService)
        {
            _serialNumberService = serialNumberService;
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}