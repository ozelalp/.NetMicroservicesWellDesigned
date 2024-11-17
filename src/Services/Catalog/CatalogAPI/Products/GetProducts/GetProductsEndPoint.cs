namespace CatalogAPI.Products.GetProducts
{
    public record GetProductsRequest();

    public record GetProductsResponse(Guid Id);

    public class GetProductsEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", () =>
            {
                return Results.Ok("Alper Bak geldi...");
            }).WithName("GetProduct")
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Products")
            .WithDescription("Get Products.");
        }
    }
}
