namespace EShop.Service.CatalogAPI.Features.Products.UpdateProduct
{
    public record UpdateProductCommand(Guid Id,string Name, List<string> Category, string Description, string ImageUrl, decimal Price) : ICommand<UpdateProductResult>;

    public record UpdateProductResult(bool IsSucess);

    internal class UpdateProductCommandHandler(IDocumentSession session, ILogger<UpdateProductCommandHandler> logger) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
    {
        public async Task<UpdateProductResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            //Logger here
            logger.LogInformation("UpdateProductCommandHandler. Handle called with {@Command}", command);

            //Business logic here
            var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

            if (product == null) 
            {
                throw new ProductNotFoundException();
            }

            product.Name = command.Name;
            product.Category = command.Category;
            product.Description = command.Description;
            product.ImageUrl = command.ImageUrl;
            product.Price = command.Price;

            // Save to db
            session.Update(product);
            await session.SaveChangesAsync(cancellationToken); // ORM generate SQL command

            return new UpdateProductResult(true);
        }
    }
}
