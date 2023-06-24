using Interfaces.UserCases;
using Interfaces.Repository;

namespace UserCases;

public class ProductManager : IProductManager
{
    IProductRepository ProductRepository { get; set; }

    public ProductManager(IProductRepository productRepository)
    {
        ProductRepository = productRepository;
    }

    public IList<Domain.Product.Product> Get()
    {
        var result = ProductRepository.Get();
        return result;
    }

    public Domain.Product.Product Get(Guid id)
    {
        var result = ProductRepository.Get(id);
        return result;
    }

    public bool Insert(Domain.Product.Product product)
    {
        var result = ProductRepository.Insert(product);
        return result;
    }

    public bool Update(Domain.Product.Product product)
    {
        var result = ProductRepository.Update(product);
        return result;
    }

    public bool Delete(Guid id)
    {
        var result = ProductRepository.Delete(id);
        return result;
    }
}
