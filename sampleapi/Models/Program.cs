using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Xml.Linq;

namespace Models;
public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public List<string> Images { get; set; }
    public string SKU { get; set; }
    public Product(Guid id, string name, string description, decimal price, List<string> images, string sKU)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Images = images;
        SKU = sKU;
    }
    public Product()
    {
        Id = Guid.Empty;
        Name = string.Empty;
        Description = string.Empty;
        Price = 0;
        Images = new List<string>();
        SKU = string.Empty;
    }
}