using ECommerce.Entities.Concrete;
using ECommerce.Entities.Models;


namespace ECommerce.Business.Abstract;

public interface ICartService
{
    void AddToCart(Cart cart, Product product);
    void RemoveFromCart(Cart cart, Product product);
    List<CartLine> GetList(Cart cart);
}
