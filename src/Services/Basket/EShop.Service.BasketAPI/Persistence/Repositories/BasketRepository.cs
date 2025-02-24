using EShop.Service.BasketAPI.Exceptions;

namespace EShop.Service.BasketAPI.Persistence.Repositories
{
    public class BasketRepository(IDocumentSession session) : IBasketRepository
    {
        public async Task<ShoppingCart> GetBasket(string username, CancellationToken cancellationToken = default)
        {
            var basket = await session.LoadAsync<ShoppingCart>(username, cancellationToken);

            if (basket == null)
            {
                throw new BasketNotFoundException(username);
            }

            return basket;
        }

        public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, CancellationToken cancellationToken = default)
        {
            // Save to db
            session.Store(basket);
            await session.SaveChangesAsync(cancellationToken); // ORM generate SQL command

            return basket;
        }

        public async Task<bool> DeleteBasket(string username, CancellationToken cancellationToken = default)
        {
            // Save to db
            session.Delete<ShoppingCart>(username);
            await session.SaveChangesAsync(cancellationToken); // ORM generate SQL command

            return true;
        }
    }
}
