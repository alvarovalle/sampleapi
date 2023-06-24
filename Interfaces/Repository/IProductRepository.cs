﻿namespace Interfaces.Repository;

public interface IProductRepository
{
    IList<Domain.Product.Product> Get();
    Domain.Product.Product Get(Guid id);
    bool Insert(Domain.Product.Product product);
    bool Update(Domain.Product.Product product);
    bool Delete(Guid id);
}