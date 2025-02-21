namespace EShop.Service.CatalogAPI.Features.Products.GetProductByCategory
{
    public record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryResult>;
    
    public record GetProductByCategoryResult(IEnumerable<Product> Products);

    internal class GetProductByCategoryQueryHandler(IDocumentSession session) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
        {
            //Queries here
            var products = await session.Query<Product>()
                                      .Where(p => p.Category.Contains(query.Category))
                                      .ToListAsync(cancellationToken);

            return new GetProductByCategoryResult(products);
        }
    }
}
