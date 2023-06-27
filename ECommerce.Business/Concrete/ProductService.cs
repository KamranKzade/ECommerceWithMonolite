﻿using ECommerce.Entities.Models;
using ECommerce.Business.Abstract;
using ECommerce.DataAccess.Abstract;


namespace ECommerce.Business.Concrete;

public class ProductService : IProductService
{
	private readonly IProductDal _productDal;

	public ProductService(IProductDal productDal)
	{
		_productDal = productDal;
	}

	public List<Product> GetAll()
	{
		return _productDal.GetList();
	}
}
