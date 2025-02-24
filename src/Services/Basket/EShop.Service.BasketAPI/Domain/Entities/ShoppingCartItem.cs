namespace EShop.Service.BasketAPI.Domain.Entities
{
    public class ShoppingCartItem
    {
        public int Quantity { get; set; } = 1;
        public string Color { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
    }
}
