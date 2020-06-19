using System.Collections.Generic;

namespace BlazorServer4.DataAccess
{
    public interface IProductData
    {
        void AddProduct(ClassLibrary.Product product);

        List<ClassLibrary.Product> GetProducts();
    }
}
