using AutoMapper;
using LightpointTestTask.BLL.Entities;
using LightpointTestTask.BLL.Infrastructure;
using LightpointTestTask.WEB.Models;
using LightpointTestTask.WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LightpointTestTask.WEB.Controllers
{
    public class ShopsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IShopsService _shopsService;

        public ShopsController(IMapper mapper, IShopsService shopsService)
        {
            _mapper = mapper;
            _shopsService = shopsService;
        }

        public IActionResult Index()
        {
            ViewBag.Title = "Магазины";
            return View(_mapper.Map<List<ShopModel>>(_shopsService.GetShops(_mapper)));
        }
        public IActionResult ShowDetails(int shopId)
        {
            ShopDetailsViewModel result = new ShopDetailsViewModel();
            result.Shop = _mapper.Map<ShopModel>(_shopsService.GetShop(shopId, _mapper));
            result.Products = _mapper.Map<List<ProductModel>>(_shopsService.GetProducts(shopId, _mapper));

            ViewBag.Title = result.Shop.Name;
            return View(result);
        }

        public IActionResult AddProduct(int ShopId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(int ShopId, ProductModel product)
        {
            product.ShopId = ShopId;
            _shopsService.AddProduct(_mapper.Map<ProductEntity>(product), _mapper);

            return RedirectToAction("ShowDetails", new { shopId = ShopId });
        }

        [HttpPost]
        public IActionResult DeleteProduct(int productId, int shopId)
        {
            _shopsService.RemoveProduct(productId);
            return RedirectToAction("ShowDetails", new { shopId });
        }

        [HttpGet]
        [ActionName("DeleteProduct")]
        public IActionResult ConfirmDeleteProduct(int productId)
        {
            var product = _mapper.Map<List<ProductModel>>(_shopsService.GetProducts(_mapper))
                .FirstOrDefault(a => a.ProductId == productId);

            if (product != null)
            {
                return View(product);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult EditProduct(int productId)
        {
            ProductModel product = null;
            var products = _mapper.Map<List<ProductModel>>(_shopsService.GetProducts(_mapper));
            foreach (var model in products)
            {
                if (model.ProductId == productId)
                {
                    product = model;
                    break;
                }
            }
            if (product != null)
            {
                return View(product);
            }
            return NotFound();

        }
        [HttpPost]
        public IActionResult EditProduct(ProductModel product)
        {
            _shopsService.UpdateProduct(_mapper.Map<ProductEntity>(product));
            return RedirectToAction("ShowDetails", new { shopId = product.ShopId });
        }
    }
}
