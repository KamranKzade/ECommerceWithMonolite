using ECommerce.Entities.Models;
using ECommerce.Core.DataAccess;


namespace ECommerce.DataAccess.Abstract;

public interface IProductDal:IEntityRepository<Product>
{
	// Ancaq producta aid olan SP, method, elave seylei bura yaziriq
}
