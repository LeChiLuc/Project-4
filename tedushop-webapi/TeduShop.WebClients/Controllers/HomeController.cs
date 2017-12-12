using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Models;

namespace TeduShop.WebClients.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {  
            return View();
        }
        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult Slider()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult Search()
        {
            return PartialView();
        }
    }
}