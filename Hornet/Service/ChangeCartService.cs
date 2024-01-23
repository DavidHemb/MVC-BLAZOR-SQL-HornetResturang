﻿using DataAccess.Models;

namespace Hornet.Service
{
    public class ChangeCartService
    {
        public string? OrderMessage { get; set; }
        public double sum;
        private Dictionary<Product, int> CartItems { get; set; } = new Dictionary<Product, int>();

        public void AddToCart(Product product, int quantity)
        {
            if (CartItems.ContainsKey(product))
            {
                CartItems[product] += quantity;
            }
            else
            {
                CartItems.Add(product, quantity);
            }
        }
        public void RemoveFromCart(Product product) 
        {
            CartItems.Remove(product);
            CalculateTotal();
        }
        public void DecreaseQuantity(Product product, int quantity) 
        {
            if (quantity>=2)
            {
                CartItems[product] --;
            }
            else
            {
                CartItems.Remove(product);
            }

            CalculateTotal();
        }
        public void IncreaseQuantity(Product product, int quantity)
        {
                CartItems[product] ++;
                CalculateTotal();
        }
        public int GetTotalQuantity()
        {
            return CartItems.Count;
        }
        public Dictionary<Product, int> GetCartItems()
        {
            return CartItems;
        }
        public void CalculateTotal()
        {
            sum = 0;

            foreach (var cartItem in GetCartItems())
            {
                sum += cartItem.Key.Price * cartItem.Value;
            }
        }
        public void ClearCart()
        {
            CartItems.Clear();
        }
    }

}
