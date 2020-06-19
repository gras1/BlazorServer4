using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorServer4.ClassLibrary
{
    public class ShoppingBasketItemProduct
    {
        public string Name { get; set; }

        public decimal PriceEach { get; set; }

        public int Quantity { get; set; }

        public decimal PriceTotal { get; set; }
    }
}
