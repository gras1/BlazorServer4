using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlazorServer4.Database
{
    public interface IDbContext : IDisposable
    {
        void RecreateDatabase();

        DbSet<Category> Categories { get; set; }

        DbSet<Product> Products { get; set; }

        DbSet<ShoppingBasketItem> ShoppingBasketItems { get; set; }

        DbSet<ShoppingBasket> ShoppingBaskets { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
