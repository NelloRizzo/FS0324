using W2_D2_SampleApplication.Models;

namespace W2_D2_SampleApplication.Services
{
    public class MemoryProductService : IProductService
    {
        private static readonly Random rnd = new Random();

        private static readonly List<Category> _categories =
            [new Category { Name = "Categoria 1", Id = 1 }, new Category { Name = "Categoria 2", Id = 2 }, new Category { Name = "Categoria 3", Id = 3 }];

        private static readonly List<Product> _products = Enumerable.Range(1, 100)
            .Select(n => new Product {
                Id = n,
                Name = $"Prodotto {n}",
                Description = $"Descrizione del prodotto {n}",
                Category = _categories[rnd.Next(3)]
            }).ToList();

        public List<Category> GetCategories() => _categories;

        public Product GetProduct(int id) => _products.FirstOrDefault(p => p.Id == id);

        public List<Product> GetProducts() => _products;

        public List<Product> GetProducts(string category) => _products.Where(p => p.Category.Name == category).ToList();
    }
}
