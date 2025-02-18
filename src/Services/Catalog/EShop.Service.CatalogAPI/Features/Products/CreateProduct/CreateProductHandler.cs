using BuidingBlocks.CQRS;
using EShop.Service.CatalogAPI.Domain.Entities;

namespace EShop.Service.CatalogAPI.Features.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageUrl, decimal Price) : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            //Business logic here

            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageUrl = command.ImageUrl,
                Price = command.Price,
            };

            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
