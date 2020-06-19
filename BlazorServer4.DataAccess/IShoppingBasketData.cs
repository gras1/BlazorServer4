using System;
using System.Threading.Tasks;

namespace BlazorServer4.DataAccess
{
    public interface IShoppingBasketData
    {
        Task<Guid> AddShoppingBasket();
    }
}