using Atlantica.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Atlantica.Api.Controllers
{
    public class HomeController : BaseController
    {
        private IMonsterService _productService;

        public HomeController(IMonsterService productService)
        {
            _productService = productService;
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
