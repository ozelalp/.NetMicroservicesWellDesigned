namespace CatalogAPI.Products.CreateProduct
{
    public record CreateProductRequest(string Name, List<string> Category, string Description, string ImageFile, decimal Price);

    public record CreateProductResponse(Guid Id);

    public class CreateProductEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/products", async (ISender mediatrSender, CreateProductRequest request) =>
            {
                var command = request.Adapt<CreateProductCommand>();
                var result = await mediatrSender.Send(command);
                var response = result.Adapt<CreateProductResponse>();
                
                return Results.Created($"/products/{response.Id}", response);
            }).WithName("CreateProduct")
            .Produces<CreateProductResponse>(StatusCodes.Status201Created)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Create Product")
            .WithDescription("Creates new Product and returns back to product page.");
        }
    }
}
