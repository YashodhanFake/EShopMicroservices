namespace EShop.Service.CatalogAPI.Features.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageUrl, decimal Price) : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    internal class CreateProductCommandHandler(IDocumentSession session, ILogger<CreateProductCommandHandler> logger) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //Logger here
            logger.LogInformation("CreateProductCommandHandler. Handle called with {@Command}", command);

            //Business logic here
            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageUrl = command.ImageUrl,
                Price = command.Price,
            };

            // Save to db
            session.Store(product); 
            await session.SaveChangesAsync(cancellationToken); // ORM generate SQL command

            return new CreateProductResult(product.Id);
        }
    }
}
