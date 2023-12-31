﻿using ECommerce.Entities.Models;


namespace ECommorce.WebUI;

public class ProductListViewModel
{
	public List<Product> Products { get; set; }
	public int CurrentCategory { get; internal set; }
	public int PageCount { get; internal set; }
	public int PageSize { get; internal set; }
	public int CurrentPage { get; internal set; }
	public bool IsClicked { get; internal set; }
}