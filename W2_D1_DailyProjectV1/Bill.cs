namespace W2_D1_DailyProjectV1
{
    public class Bill
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public decimal Amount { get; set; }
        public decimal TableService { get; set; } = 3;
    }
}
