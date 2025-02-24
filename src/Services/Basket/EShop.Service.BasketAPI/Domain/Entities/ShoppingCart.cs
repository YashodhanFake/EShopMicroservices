namespace EShop.Service.BasketAPI.Domain.Entities
{
    public class ShoppingCart
    {
        public string Username { get; set; } = string.Empty;
        public List<ShoppingCartItem> Items { get; set; } = new();
        public decimal TotalAmount => Items.Sum(sci => sci.Price * sci.Quantity);
        public ShoppingCart(string username)
        {
            Username = username;
        }

        //Required for mapping
        public ShoppingCart()
        {
        }
    }
}
