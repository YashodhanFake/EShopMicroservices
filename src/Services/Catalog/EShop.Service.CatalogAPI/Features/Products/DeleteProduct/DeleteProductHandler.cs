namespace EShop.Service.CatalogAPI.Features.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid Id) : ICommand<DeleteProductResult>;

    public record DeleteProductResult(bool IsSuccess);

    public class DeleteProductCommandHandler(IDocumentSession session) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
    {
        public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            // Save to db
            session.Delete<Product>(command.Id);
            await session.SaveChangesAsync(cancellationToken); // ORM generate SQL command

            return new DeleteProductResult(true);
        }
    }
}
