using ECommerce.Entities.Models;


namespace ECommerce.Business.Abstract;

public interface IProductService
{
	List<Product> GetAll();
	List<Product> GetAllByCategoryId(int id);
	Product GetById(int id);
}
