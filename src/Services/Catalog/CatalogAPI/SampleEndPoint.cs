
namespace CatalogAPI
{
    public class SampleEndPoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/hede", (ISender sender, string welcome) =>
            {
                return "Alper";
            });
        }
    }
}
