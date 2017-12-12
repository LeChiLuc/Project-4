using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Models;

namespace TeduShop.Web.ClientsControllers
{
    public class HomeController : Controller
    {
        IProductCategoryService _productCategogyService;
        public HomeController(IProductCategoryService productCategogyService)
        {
            this._productCategogyService = productCategogyService;
        }
        // GET: Home
        public ActionResult Index()
        {
            var model = _productCategogyService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            return View(listProductCategoryViewModel);
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