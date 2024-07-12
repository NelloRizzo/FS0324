namespace BuildWeek1.BusinessLayer.Dto
{
    public class CartItemDto : DtoBase
    {
        public required ProductDto Product { get; set; }
        public int Quantity { get; set; }

        public override bool IsValid => base.IsValid && Quantity > 0;
    }
}
