using Interview.Web.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interview.Web.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductsAsync();

        Task<bool> AddProductAsync(ProductDto product);

        Task<IEnumerable<ProductDto>> SearchProductsAsync(string searchText);
    }
}
