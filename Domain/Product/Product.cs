namespace Domain.Product;
public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public List<string> Images { get; set; }
    public string SKU { get; set; }

    public Action<string> OutputLog { get; set; }
    public Func<Domain.Product.Product, bool> OnCreate { get; set; }
    public Func<Domain.Product.Product, bool> OnModify { get; set; }

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
    public Notifications Create()
    {
        Id = Guid.NewGuid();
        OutputLog($"DOMAIN Product Create [SKU: {SKU}, Name: {Name}, Description: {Description}, Price:{Price}]");
        var notifications = Validations();

        if (notifications.Success)
            notifications.Success = OnCreate(this);

        return notifications;
    }
    public Notifications Modify()
    {
        OutputLog($"DOMAIN Product Modify [SKU: {SKU}, Name: {Name}, Description: {Description}, Price:{Price}]");
        var notifications = Validations();

        if (notifications.Success)
            notifications.Success = OnModify(this);

        return notifications;
    }
    public Notifications Validations()
    {
        var notifications = new Notifications();

        if (string.IsNullOrWhiteSpace(Name))
        {
            notifications.Add("Name is required!");
        }
        if (string.IsNullOrWhiteSpace(Description))
        {
            notifications.Add("Description is required!");
        }
        if (string.IsNullOrWhiteSpace(SKU))
        {
            notifications.Add("SKU is required!");
        }
        if (Price <= 0)
        {
            notifications.Add("Price must be greater than zero!");
        }

        if (notifications.Count > 0)
            notifications.Success = false;

        return notifications;
    }
}