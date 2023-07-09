namespace Api.Models;
public class ProductInput
{
 
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public List<string> Images { get; set; }
    public string SKU { get; set; }
    public Domain.Product.Product ToDomain(Guid id)
    {
        return new Domain.Product.Product(id, Name, Description, Price, Images, SKU);
    }
    public Domain.Product.Product ToDomain()
    {
        return new Domain.Product.Product(Guid.Empty, Name, Description, Price, Images, SKU);
    }
    
    public ProductInput()
    {

    }
   
}