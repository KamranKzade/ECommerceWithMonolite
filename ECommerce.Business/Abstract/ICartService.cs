using ECommerce.Entities.Concrete;
using ECommerce.Entities.Models;


namespace ECommerce.Business.Abstract;

public interface ICartService
{
    void AddToCart(Cart cart, Product product);
    void RemoveFromCart(Cart cart, int productId);
    void IncreaseQuantity(Cart cart, int productId);
    void DecreaseQuantity(Cart cart, int productId);
    List<CartLine> GetList(Cart cart);
}
