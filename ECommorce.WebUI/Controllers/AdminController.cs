using Microsoft.AspNetCore.Mvc;
using ECommerce.Entities.Models;
using ECommerce.Business.Abstract;
using Microsoft.AspNetCore.Authorization;

namespace ECommorce.WebUI.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{

	private readonly IProductService _productService;
	private readonly ICategoryService _categoryService;

	public AdminController(IProductService productService, ICategoryService categoryService)
	{
		_productService = productService;
		_categoryService = categoryService;
	}

	public IActionResult Index(int page = 1, int category = 0, bool isClicked = false)
	{
		int pageSize = 10;
		var products = _productService.GetAllByCategoryId(category);
		if (isClicked)
		{
			products = products.OrderByDescending(x => x.UnitPrice).ToList();
		}
		else
		{
			products = products.OrderBy(x => x.UnitPrice).ToList();
		}
		var model = new ProductListViewModel
		{
			Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
			CurrentCategory = category,
			PageCount = (int)Math.Ceiling(products.Count / (double)pageSize),
			PageSize = pageSize,
			CurrentPage = page,
			IsClicked = isClicked
		};
		return View(model);
	}

	[HttpGet]
	public IActionResult Add()
	{
		var model = new ProductAddViewModel();

		model.Product = new Product();
		model.Categories = _categoryService.GetAll();

		return View(model);

	}

	[HttpPost]
	public IActionResult Add(ProductAddViewModel model)
	{
		_productService.Add(model.Product);
		return RedirectToAction("Index");
	}
}
