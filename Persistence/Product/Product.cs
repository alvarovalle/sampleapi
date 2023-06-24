namespace Persistence.Product;
public class Product
{
    [BsonId]
    [BsonElement("_id")]
    public ObjectId _Id { get; set; }
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public List<string> Images { get; set; }
    public string SKU { get; set; }

    public Product(Domain.Product.Product product)
    {
        Id = product.Id;
        Name = product.Name;
        Description = product.Description;
        Price = product.Price;
        Images = product.Images;
        SKU = product.SKU;
    }
    public Domain.Product.Product ToProduct()
    {
        return new Domain.Product.Product(Id, Name, Description, Price, Images, SKU);
    }
}