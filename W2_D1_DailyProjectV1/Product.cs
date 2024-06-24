using System.Text;

namespace W2_D1_DailyProjectV1
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Quantity { get; set; }
        public string MeasureUnit { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public override string ToString() {
            var result = new StringBuilder()
                .Append($"{Id}.\t{Name}");
            if (Quantity > 0) {
                result.Append($" {Quantity} {MeasureUnit}");
            }
            return result.Append($"\t{UnitPrice:C}").ToString();
        }
    }
}
