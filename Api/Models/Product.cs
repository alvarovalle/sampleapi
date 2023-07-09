namespace Api.Models;
public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public List<string> Images { get; set; }
    public string SKU { get; set; }
    public Product()
    {

    }
    public Product(Domain.Product.Product product)
    {
        if (product != null)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            Images = product.Images;
            SKU = product.SKU;
        }
    }
    public static List<Product> ToList(List<Domain.Product.Product> products)
    {
        List<Product> _products = new List<Product>();
        if (products != null)
        {
            foreach (var product in products)
                _products.Add(new Product(product));
        }
        return _products;
    }

}