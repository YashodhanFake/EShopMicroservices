namespace EShop.Service.CatalogAPI.Features.Products.GetProducts
{
    public record GetProductsQuery() : IQuery<GetProductsResult>;

    public record GetProductsResult(IEnumerable<Product> Products);

    internal class GetProductsQueryHandler(IDocumentSession session, ILogger<GetProductsQueryHandler> logger) : IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            //Logger here
            logger.LogInformation("GetProductsQueryHandler. Handle called with {@Query}", query);

            //Queries here
            var products = await session.Query<Product>().ToListAsync(cancellationToken);

            return new GetProductsResult(products);
        }
    }
}
