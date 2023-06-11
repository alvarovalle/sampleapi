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
        Application.MapGet("/product", () =>
        {
            return new List<Models.Product>();
        })
        .WithName("GetWeatherForecast")
        .WithOpenApi();
    }
}
