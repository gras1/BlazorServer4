using BlazorServer4.ClassLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorServer4.DataAccess
{
    public interface IProductCategoryData
    {
        Task<ICollection<ProductCategory>> GetAllAsync();

        Task<ICollection<ProductCategory>> SearchProductsAsync(string searchTerm);
    }
}