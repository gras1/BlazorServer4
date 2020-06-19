using BlazorServer4.Database;
using System;
using System.Threading.Tasks;

namespace BlazorServer4.DataAccess
{
    public class ShoppingBasketData : IShoppingBasketData
    {
        private readonly IDbContext _dbContext;

        public ShoppingBasketData(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> AddShoppingBasket()
        {
            var newShoppingBasket = new ShoppingBasket
            {
                ShoppingBasketId = Guid.NewGuid(),
                CreatedDateTime = DateTime.Now
            };
            _dbContext.ShoppingBaskets.Add(newShoppingBasket);
            await _dbContext.SaveChangesAsync();

            return newShoppingBasket.ShoppingBasketId;
        }

        ~ShoppingBasketData()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
        }
    }
}
