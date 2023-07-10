﻿using ECommorce.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Business.Abstract;
using ECommerce.Entities.Concrete;

namespace ECommorce.WebUI.Controllers;

public class CartController : Controller
{
	private ICartSessionService _cartSessionService;
	private ICartService _cartService;
	private IProductService _productService;

	public CartController(ICartSessionService cartSessionService, ICartService cartService, IProductService productService)
	{
		_cartSessionService = cartSessionService;
		_cartService = cartService;
		_productService = productService;
	}

	public IActionResult AddToCart(int productId)
	{
		var productToAdded = _productService.GetById(productId);
		var cart = _cartSessionService.GetCart();

		_cartService.AddToCart(cart, productToAdded);
		_cartSessionService.SetCart(cart);

		TempData.Add("message", String.Format("Your product, {0} was added succesfully to cart!", productToAdded.ProductName));
		return RedirectToAction("Index", "Product");
	}

	public IActionResult Index()
	{
		var cart = _cartSessionService.GetCart();
		return View();
	}

	public IActionResult List()
	{
		var cart = _cartSessionService.GetCart();

		var model = new CartListViewModel
		{
			Cart = cart
		};

		return View(model);
	}

	public IActionResult Remove(int productId)
	{
		var cart = _cartSessionService.GetCart();

		_cartService.RemoveFromCart(cart, productId);

		_cartSessionService.SetCart(cart);

		TempData.Add("message", "Your Product was removed successfully from cart");
		return RedirectToAction("List");
	}

	[HttpGet]
	public IActionResult Complete()
	{
		var shippingDetail = new ShippingDetailViewModel
		{
			ShippingDetails = new ShippingDetails()
		};

		return View(shippingDetail);
	}

	[HttpPost]
	public IActionResult Complete(ShippingDetailViewModel model)
	{
		if (!ModelState.IsValid)
		{
			return View();
		}
		TempData.Add("message", String.Format("Thank you {0}, your order is in progress", model.ShippingDetails.Firstname));
		return RedirectToAction("Index", "Product");
	}

	public IActionResult Increase(int ProductId)
	{
		var cart = _cartSessionService.GetCart();
		_cartService.IncreaseQuantity(cart, ProductId);
		_cartSessionService.SetCart(cart);
		return RedirectToAction("List");
	}
	public IActionResult Decrease(int ProductId)
	{
		var cart = _cartSessionService.GetCart();
		_cartService.DecreaseQuantity(cart, ProductId);
		_cartSessionService.SetCart(cart);
		return RedirectToAction("List");
	}
}
