namespace EShop.Service.CatalogAPI.Features.Products.GetProductByCategory
{
    public record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryResult>;
    
    public record GetProductByCategoryResult(IEnumerable<Product> Products);

    internal class GetProductByCategoryQueryHandler(IDocumentSession session, ILogger<GetProductByCategoryQueryHandler> logger) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            //Logger here
            logger.LogInformation("GetProductByCategoryQueryHandler. Handle called with {@Query}", query);

            //Queries here
            var products = await session.Query<Product>()
                                      .Where(p => p.Category.Contains(query.Category))
                                      .ToListAsync(cancellationToken);

            return new GetProductByCategoryResult(products);
        }
    }
}
