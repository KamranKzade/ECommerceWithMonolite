using ECommerce.Entities.Models;

namespace ECommorce.WebUI
{
	public class CategoryListViewModel
	{
		public List<Category> Categories { get; set; }
		public int CurrentCategory { get; set; }
	}
}