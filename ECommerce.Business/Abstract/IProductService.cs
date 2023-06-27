using ECommerce.Entities.Models;


namespace ECommerce.Business.Abstract;

public interface IProductService
{
	List<Product> GetAll();
}
