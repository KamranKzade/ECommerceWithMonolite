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

	public List<Product> GetAllByCategoryId(int id)
	{
		return _productDal.GetList(p => p.CategoryId == id || id == 0);
	}

    public Product GetById(int id)
    {
       return _productDal.Get(p => p.ProductId == id);
    }

}
