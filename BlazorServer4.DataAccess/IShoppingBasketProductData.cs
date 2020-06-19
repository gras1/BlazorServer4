using BlazorServer4.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServer4.DataAccess
{
    public interface IShoppingBasketProductData
    {
        Task<ICollection<ShoppingBasketItemProduct>> GetShoppingBasketItems(Guid shoppingBasketId);
    }
}
