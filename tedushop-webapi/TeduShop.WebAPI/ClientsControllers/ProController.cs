using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using TeduShop.Common;
using TeduShop.Model.Models;
using TeduShop.Service;
using TeduShop.Web.Infrastructure.Core;
using TeduShop.Web.Models;

namespace TeduShop.Web.ClientsControllers
{
    public class ProController : Controller
    {
        IProductCategoryService _productCategogyService;
        IProductService _productService;
        IProductQuantityService _productQuantityService;
        public ProController(IProductCategoryService productCategogyService, IProductService productService,IProductQuantityService productQuantityService)
        {
            this._productCategogyService = productCategogyService;
            this._productService = productService;
            this._productQuantityService = productQuantityService;
        }
        // GET: Pro
        public ActionResult Category(int id, int page = 1)
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;
            var listProduct = _productService.GetListProductByCategoryIdPaging(id, page, pageSize, out totalRow);
            var productViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(listProduct);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = productViewModel,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
                PageIndex = page,
                TotalRows = totalRow,
                TotalPages = totalPage
            };
            ViewBag.listProduct = paginationSet;
            var model = _productCategogyService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            return View(listProductCategoryViewModel);
        }
        public ActionResult Search(string keyword, int page = 1)
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;
            var listProduct = _productService.Search(keyword, page, pageSize, out totalRow);
            var productViewModel = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(listProduct);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            ViewBag.Keyword = keyword;
            var paginationSet = new PaginationSet<ProductViewModel>()
            {
                Items = productViewModel,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
                PageIndex = page,
                TotalRows = totalRow,
                TotalPages = totalPage
            };
            ViewBag.listProduct = paginationSet;
            var model = _productCategogyService.GetAll();
            var listProductCategoryViewModel = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            return View(listProductCategoryViewModel);
        }
        public ActionResult Detail(int id)
        {
            var model = _productCategogyService.GetAll();
            ViewBag.listProductCategory = Mapper.Map<IEnumerable<ProductCategory>, IEnumerable<ProductCategoryViewModel>>(model);
            //var quantityProduct = _productQuantityService.GetById(id);
            //ViewBag.quantityViewModel = Mapper.Map<ProductQuantity, ProductQuantityViewModel>(quantityProduct);
            var relatedProduct = _productService.GetReatedProducts(id, 6);
            ViewBag.RelatedProducts = Mapper.Map<IEnumerable<Product>,IEnumerable<ProductViewModel>>(relatedProduct);
            
            var productModel = _productService.GetById(id);
            var viewModel = Mapper.Map<Product,ProductViewModel> (productModel);

            return View(viewModel);
        }
        public JsonResult GetListProductByName(string keyword)
        {
            var model = _productService.GetListProductByName(keyword);
            return Json(new
            {
                data = model
            }, JsonRequestBehavior.AllowGet);
        }
    }
}