namespace W2_D1_DailyProjectV1
{
    public class ProductService : IProductService
    {
        private List<Product> allProducts = [
            new Product{Id = 1, MeasureUnit = "ml", Name="Coca Cola", Quantity = 150, UnitPrice = 2.5m },
            new Product{Id = 2, Name = "Insalata di Pollo", UnitPrice = 5.2m},
            new Product{Id = 3, Name = "Pizza Margherita", UnitPrice = 10},
            new Product{Id = 4, Name = "Pizza 4 Formaggi", UnitPrice =12.5m },
            new Product{Id = 5, Name = "Patatine Fritte", MeasureUnit = "pz", Quantity = 1, UnitPrice = 3.5m },
            new Product{Id = 6, Name = "Insalata di Riso", UnitPrice=8 },
            new Product{Id = 7, Name = "Frutta di Stagione", UnitPrice=5 },
            new Product{Id = 8, Name = "Pizza Fritta", UnitPrice = 5 },
            new Product{Id = 9, Name = "Piadina Vegetariana", UnitPrice = 6 },
            new Product{Id = 10, Name = "Panino Hamburgher", UnitPrice = 7.9m }
            ];

        private Bill bill = new Bill();

        public Bill GetBill() {
            var amount = 0m;
            foreach (var product in bill.Products) {
                amount += product.UnitPrice;
            }
            bill.Amount = amount + bill.TableService;
            return bill;
        }

        public List<Product> GetProducts() {
            return allProducts;
        }

        public void NewOrder() {
            bill = new Bill();
        }

        public void SelectProduct(int id) {
            var product = allProducts[id - 1];
            bill.Products.Add(product);
        }
    }
}
