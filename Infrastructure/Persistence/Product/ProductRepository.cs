namespace Infrastructure.Persistence.Product;
using Interfaces.Persistence.Product;

public class ProductRepository : IProductRepository
{
    public bool Delete(Guid id)
    {
        var conn = new MainContext();
        var filterBuilder = Builders<Product>.Filter;
        var filter = filterBuilder.Eq(p=>p.Id, id);
        conn.Product.DeleteMany(filter);
        return true;
    }

    public IList<Domain.Product.Product> Get()
    {
        var conn = new MainContext();
        var _products = conn.Product.Find(p => true).ToList();
        if (_products.Count() == 0) return new List<Domain.Product.Product>();
        return _products.Select(p=>p.ToProduct()).ToList();
    }

    public Domain.Product.Product Get(Guid id)
    {
        var conn = new MainContext();
        var _product = conn.Product.Find(p=>p.Id.Equals(id)).FirstOrDefault();
        if (_product == null) return new Domain.Product.Product();
        return _product.ToProduct();
    }

    public bool Insert(Domain.Product.Product product)
    {
        var conn = new MainContext();
        var _product = new Product(product); 
        conn.Product.InsertOne(_product);
        return true;
    }

    public bool Update(Domain.Product.Product product)
    {
        var conn = new MainContext();
        var _product = new Product(product); 
        var filterBuilder = Builders<Product>.Filter;
        var filter = filterBuilder.Eq(p=>p.Id, product.Id);
        var updateBuilder = Builders<Product>.Update;
        var update = updateBuilder
        .Set(p=>p.Name, product.Name)
        .Set(p=>p.Description, product.Description)
        .Set(p=>p.Price, product.Price)
        .Set(p=>p.Images, product.Images)
        .Set(p=>p.SKU, product.SKU);

        conn.Product.UpdateMany(filter,update);

        return true;
    }
}
