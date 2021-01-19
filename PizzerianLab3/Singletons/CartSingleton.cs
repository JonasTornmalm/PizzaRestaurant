using PizzerianLab3.Data.Entities;
using System;
using System.Collections.Generic;

namespace PizzerianLab3
{
    public class CartSingleton
    {
        public Order Order;

        public CartSingleton()
        {
            Order = new Order();
        }
        internal void Empty()
        {
            if (!Order.IsEmpty)
            {
                Order.Id = Guid.Empty;
                Order.Pizzas = new List<Pizza>();
                Order.Sodas = new List<Soda>();
                Order.TotalPrice = 0;
            }
        }
    }
}
