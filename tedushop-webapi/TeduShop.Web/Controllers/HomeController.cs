using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Models;

namespace TeduShop.Web.Controllers
{
    public class HomeController : Controller
    {
        IProductCategoryService _productCategoryService;

        public HomeController(IProductCategoryService productCategoryService)
        {
            this._productCategoryService = productCategoryService;
        }
        public ActionResult Index()
        {
            var model = _productCategoryService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            return View(listProductCategoryViewModel);
        }
        [ChildActionOnly]
        public ActionResult _Footer()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult _Header()
        {
            return PartialView();
        }
        [ChildActionOnly]
        public ActionResult _Menu()
        {
            return PartialView();
        }
    }
}