namespace EShop.Service.CatalogAPI.Features.Products.CreateProduct
{
    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageUrl, decimal Price) : ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(command => command.Name)
               .NotEmpty().WithMessage("Name is required")
               .Length(2, 150).WithMessage("Name must be between 2 and 150 characters");

            RuleFor(x => x.Category).NotEmpty().WithMessage("Category is required");

            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("ImageUrl is required");

            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        }
    }
    internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
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

            // Save to db
            session.Store(product); 
            await session.SaveChangesAsync(cancellationToken); // ORM generate SQL command

            return new CreateProductResult(product.Id);
        }
    }
}
