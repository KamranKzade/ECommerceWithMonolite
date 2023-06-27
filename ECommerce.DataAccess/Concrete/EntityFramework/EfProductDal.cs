using ECommerce.Entities.Models;
using ECommerce.DataAccess.Abstract;
using ECommerce.Core.DataAccess.EntityFramework;

namespace ECommerce.DataAccess.Concrete.EntityFramework;

public class EfProductDal :EfEntityRepositoryBase<Product, NorthwindContext>,IProductDal
{
}
