using Interfaces.Repository;
using Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence;

public class ProductRepository : IProductRepository
{
    public bool Delete(Guid id)
    {

        return true;
    }

    public IList<Models.Product> Get()
    {
        var conn = new MainContext();
        var _products = conn.Product.Find(p => true).ToList();
        if (_products.Count() == 0) return new List<Models.Product>();
        return _products.Select(p=>p.ToProduct()).ToList();
    }

    public Models.Product Get(Guid id)
    {
        var conn = new MainContext();
        var _product = conn.Product.Find(p=>p.Id.Equals(id)).FirstOrDefault();
        if (_product == null) return new Models.Product();
        return _product.ToProduct();
    }

    public bool Insert(Models.Product product)
    {
        var conn = new MainContext();
        var _product = new Product(product); 
        conn.Product.InsertOne(_product);
        return true;
    }

    public bool Update(Models.Product product)
    {
        throw new NotImplementedException();
    }
}
