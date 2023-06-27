using Microsoft.AspNetCore.Mvc;
using ECommerce.Business.Abstract;


namespace ECommorce.WebUI.Controllers;


public class ProductController : Controller
{
	private readonly IProductService _productService;

	public ProductController(IProductService productService)
	{
		_productService = productService;
	}

	public IActionResult Index(int page = 1, int category = 0, bool isClicked = false)
	{
		int pageSize = 10;
		var products = _productService.GetAllByCategoryId(category);
		if (isClicked)
		{
			products= products.OrderByDescending(x => x.UnitPrice).ToList();
		}
		else
		{
			products= products.OrderBy(x => x.UnitPrice).ToList();
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
}
