using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repository
{
    public interface IRepositoryManager
    {
        IProductRepository ProductRepository { get; }
        IUnitOfWork UnitOfWork { get; }
    }
}
