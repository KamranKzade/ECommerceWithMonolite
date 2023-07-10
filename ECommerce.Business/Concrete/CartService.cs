using ECommerce.Entities.Models;
using ECommerce.Business.Abstract;
using ECommerce.Entities.Concrete;


namespace ECommerce.Business.Concrete;

public class CartService : ICartService
{
	public void AddToCart(Cart cart, Product product)
	{
		CartLine cartLine = cart.CartLines.FirstOrDefault(c => c.Product.ProductId == product.ProductId);

		if (cartLine != null)
		{
			cartLine.Quantity++;
		}
		else
		{
			cart.CartLines.Add(new CartLine { Quantity = 1, Product = product });
		}
	}

	public void DecreaseQuantity(Cart cart, int productId)
	{
		var cartline = cart.CartLines.FirstOrDefault(c => c.Product.ProductId == productId);
		if (cartline.Quantity > 0)
		{
			cartline.Quantity--;
		}
	}

	public List<CartLine> GetList(Cart cart)
	{
		return cart.CartLines;
	}

	public void IncreaseQuantity(Cart cart, int productId)
	{
		var cartline = cart.CartLines.FirstOrDefault(c => c.Product.ProductId == productId);
		if (cartline.Quantity < cartline.Product.UnitsInStock)
		{
			cartline.Quantity++;
		}
	}

	public void RemoveFromCart(Cart cart, int productId)
	{
		cart.CartLines.Remove(cart.CartLines.FirstOrDefault(c => c.Product.ProductId == productId));
	}
}
