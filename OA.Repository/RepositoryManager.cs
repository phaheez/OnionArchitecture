using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IProductRepository> _lazyProductRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(RepositoryContext context)
        {
            _lazyProductRepository = new Lazy<IProductRepository>(() => new ProductRepository(context));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(context));
        }

        public IProductRepository ProductRepository => _lazyProductRepository.Value;
        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    }
}
