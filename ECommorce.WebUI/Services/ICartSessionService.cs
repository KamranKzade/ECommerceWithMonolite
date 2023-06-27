using ECommerce.Entities.Concrete;


namespace ECommorce.WebUI.Services;

public interface ICartSessionService
{
    Cart GetCart();
    void SetCart(Cart cart);
}
