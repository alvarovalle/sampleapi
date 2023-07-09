namespace Interfaces.UserCases;

public interface IProductManager
{
    List<Domain.Product.Product> Get();
    Domain.Product.Product Get(Guid id);
    Notifications Modify(Domain.Product.Product product);
    Notifications Create(Domain.Product.Product product);
    bool Delete(Guid id);
}