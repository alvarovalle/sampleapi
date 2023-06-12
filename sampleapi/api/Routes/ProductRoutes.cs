using Interfaces.Repository;

namespace Api.Routes;

public class ProductRoutes
{
    WebApplication Application { get; set; }
    public ProductRoutes(WebApplication app)
    {
        Application = app;
    }
    public void Start()
    {
        Application.MapGet("/product", (IProductRepository repo) =>
        {
            return repo.Get();
        })
        .WithName("GetProducts")
        .WithOpenApi();
        
        Application.MapGet("/product/{id}", (IProductRepository repo, Guid id) =>
        {
            return repo.Get(id);
        })
       .WithName("GetProductById")
       .WithOpenApi();

        Application.MapPost("/product", (IProductRepository repo, Models.Product product) =>
        {
            return repo.Insert(product);
        })
        .WithName("CreateProduct")
        .WithOpenApi();

    }
}
