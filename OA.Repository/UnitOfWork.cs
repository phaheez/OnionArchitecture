using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly RepositoryContext _context;

        public UnitOfWork(RepositoryContext context) => _context = context;

        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();
    }
}
