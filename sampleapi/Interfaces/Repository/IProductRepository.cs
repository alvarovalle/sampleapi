using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Repository;

public interface IProductRepository
{
    IList<Models.Product> Get();
    Models.Product Get(Guid id);
    bool Insert(Models.Product product);
    bool Update(Models.Product product);
    bool Delete(Guid id);

}
