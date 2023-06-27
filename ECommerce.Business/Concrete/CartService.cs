﻿using ECommerce.Entities.Models;
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

    public List<CartLine> GetList(Cart cart)
    {
        return cart.CartLines;
    }

    public void RemoveFromCart(Cart cart, Product product)
    {
        cart.CartLines.Remove(cart.CartLines.FirstOrDefault(c => c.Product.ProductId == product.ProductId));
    }
}