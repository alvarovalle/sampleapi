using Interfaces.UserCases;

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
        Application.MapGet("/",()=>
           Results.Extensions.Html(@$"<!doctype html>
              <html>
              <head><title>Product</title></head>
              <body>
                 <a href='/swagger/index.html'>start here</a>
              </body>
              </html>"));

        Application.MapGet("/product", (IProductManager srv) =>
        {
            return srv.Get();
        })
        .WithName("GetProducts")
        .WithOpenApi();
        
        Application.MapGet("/product/{id}", (IProductManager srv, Guid id) =>
        {
            return srv.Get(id);
        })
       .WithName("GetProductById")
       .WithOpenApi();

        Application.MapPost("/product", (IProductManager srv, Domain.Product.Product product) =>
        {
            return srv.Create(product);
        })
        .WithName("CreateProduct")
        .WithOpenApi();
        
        Application.MapPut("/product", (IProductManager srv, Domain.Product.Product product) =>
        {
            return srv.Modify(product);
        })
        .WithName("UpdateProduct")
        .WithOpenApi();

        Application.MapDelete("/product", (IProductManager srv, Guid id) =>
        {
            return srv.Delete(id);
        })
        .WithName("DeleteProduct")
        .WithOpenApi();
    }
}
