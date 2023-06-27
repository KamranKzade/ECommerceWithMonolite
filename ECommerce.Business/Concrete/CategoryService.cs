using ECommerce.Business.Abstract;
using ECommerce.Entities.Models;
using ECommerce.DataAccess.Abstract;

namespace ECommerce.Business.Concrete;

public class CategoryService : ICategoryService
{
	private readonly ICategoryDal _categoryDal;

	public CategoryService(ICategoryDal categoryDal)
	{
		_categoryDal = categoryDal;
	}

	public List<Category> GetAll()
	{
		return _categoryDal.GetList();
	}
}
