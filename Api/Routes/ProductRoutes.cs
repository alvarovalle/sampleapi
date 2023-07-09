using Interfaces.UserCases;
using Api.Models;

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
        Application.MapGet("/v1/product", IResult (IProductManager srv) =>
        {
            Console.WriteLine($"HTTP REQUEST GET /v1/product");
            var result = Product.ToList(srv.Get());
            if (result.Count == 0)
            {
                Console.WriteLine($"HTTP RESPONSE GET /v1/product NOT FOUND");
                return TypedResults.NotFound(result);
            }
            else
            {
                Console.WriteLine($"HTTP RESPONSE GET /v1/product OK");
                return TypedResults.Ok(result);
            }

        })
        .WithName("GetProducts")
        .WithOpenApi();

        Application.MapGet("/v1/product/{id}", IResult (IProductManager srv, Guid id) =>
        {
            Console.WriteLine($"HTTP REQUEST GET /v1/product/{id}");
            var result = new Product(srv.Get(id));
            if (result.Id == Guid.Empty)
            {
                Console.WriteLine($"HTTP RESPONSE GET /v1/product/{id} NOT FOUND");
                return TypedResults.NotFound(result);
            }
            else
            {
                Console.WriteLine($"HTTP RESPONSE GET /v1/product/{id} OK");
                return TypedResults.Ok(result);
            }
        })
       .WithName("GetProductById")
       .WithOpenApi();

        Application.MapPost("/v1/product", IResult (IProductManager srv, ProductInput product) =>
        {
            Console.WriteLine($"HTTP REQUEST POST /v1/product [SKU: {product.SKU}, Name: {product.Name}, Description: {product.Description}, Price: {product.Price}]");
            var result = srv.Create(product.ToDomain());
            if (result.Success)
            {
                Console.WriteLine($"HTTP RESPONSE POST /v1/product CREATED");
                return TypedResults.Created("/v1/product");
            }
            else
            {
                Console.WriteLine($"HTTP RESPONSE POST /v1/product UNPROCESSABLE ENTITY");
                return TypedResults.UnprocessableEntity(result);
            }

        })
        .WithName("CreateProduct")
        .WithOpenApi();

        Application.MapPut("/v1/product/{id}", IResult (IProductManager srv,Guid id,  ProductInput product) =>
        {
            Console.WriteLine($"HTTP PUT /v1/product/{id} [ID: {id}  SKU: {product.SKU}, Name: {product.Name}, Description: {product.Description}, Price: {product.Price}]");
            var result = srv.Modify(product.ToDomain(id));
            if (result.Success)
            {
                Console.WriteLine($"HTTP RESPONSE POST /v1/product ACCEPTED");
                return TypedResults.Accepted($"/v1/product/{id}");
            }
            else
            {
                Console.WriteLine($"HTTP RESPONSE POST /v1/product UNPROCESSABLE ENTITY");
                return TypedResults.UnprocessableEntity(result);
            }
        })
        .WithName("UpdateProduct")
        .WithOpenApi();

        Application.MapDelete("/v1/product/{id}", IResult (IProductManager srv, Guid id) =>
        {
            Console.WriteLine($"HTTP DELETE /v1/product/{id}");
            var result = srv.Delete(id);
               if (result)
            {
                Console.WriteLine($"HTTP RESPONSE DELETE /v1/product ACCEPTED");
                return TypedResults.Accepted($"/v1/product/{id}");
            }
            else
            {
                Console.WriteLine($"HTTP RESPONSE DELETE /v1/product NOT FOUND");
                return TypedResults.NotFound(result);
            }
        })
        .WithName("DeleteProduct")
        .WithOpenApi();
    }
}
