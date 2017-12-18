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
        ICommonService _commonService;
        IProductService _productService;
        public HomeController(IProductCategoryService productCategogyService,ICommonService commonservice,IProductService productService)
        {
            this._productCategogyService = productCategogyService;
            this._commonService = commonservice;
            this._productService = productService;
        }
        // GET: Home
        public ActionResult Index()
        {
            var slide = _commonService.GetSlides();
            ViewBag.listSlideViewModel = Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(slide);
            var model = _productCategogyService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            var lastestProductModel = _productService.GetLastest(6);
            var topHotProductModel = _productService.GetHotProduct(6);
            var lastestProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(lastestProductModel);
            var topHotProductViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(topHotProductModel);

            ViewBag.lastestProductView = lastestProductViewModel;
            ViewBag.topHotProductView = topHotProductViewModel;
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
        public ActionResult Search()
        {
            return PartialView();
        }
    }
}