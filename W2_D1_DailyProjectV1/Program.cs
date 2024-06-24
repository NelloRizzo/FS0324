using W2_D1_DailyProjectV1;

namespace Application
{
    public class Program
    {
        static int Menu(List<Product> products) {
            Console.WriteLine("********************* Menu ********************");
            foreach (var product in products) {
                Console.WriteLine(product);
            }
            Console.WriteLine("0.\tStampa conto finale");
            Console.WriteLine();
            Console.Write("Scegli: ");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 0 || choice > products.Count) {
                Console.WriteLine($"Per favore inserisci un numero compreso tra 0 e {products.Count}");
            }
            return choice;
        }
        static void Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bool emitBill = false;
            IProductService productService = new ProductService();
            do {
                int choice = Menu(productService.GetProducts());
                switch (choice) {
                    case 0: emitBill = true; break;
                    default: productService.SelectProduct(choice); break;
                }
            } while (!emitBill);
            Console.WriteLine("Scontrino");
            var bill = productService.GetBill();
            foreach (var product in bill.Products) {
                Console.WriteLine(product);
            }
            Console.WriteLine($"Servizio al tavolo: {bill.TableService:C}");
            Console.WriteLine($"TOTALE DA PAGARE: {bill.Amount:C}");
        }
    }
}