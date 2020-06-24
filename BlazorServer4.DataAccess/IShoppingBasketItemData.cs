using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServer4.DataAccess
{
    public interface IShoppingBasketItemData
    {
        Task AddShoppingBasketItem(ClassLibrary.ShoppingBasketItem shoppingBasketItem);

        IAsyncEnumerable<ClassLibrary.ShoppingBasketItem> GetShoppingBasketItems(Guid shoppingBasketId);

        Task<int> GetShoppingBasketItemQuantity(Guid shoppingBasketId);

        Task DeleteShoppingBasketItem(Guid shoppingBasketId, int productId);
    }
}