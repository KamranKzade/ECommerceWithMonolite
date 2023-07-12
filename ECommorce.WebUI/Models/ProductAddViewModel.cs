using ECommerce.Entities.Models;

namespace ECommorce.WebUI
{
    public class ProductAddViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
    }
}