using W2_D2_SampleApplication.Models;

namespace W2_D2_SampleApplication.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
        List<Product> GetProducts(string category);
        Product GetProduct(int id);

        List<Category> GetCategories();
    }
}
