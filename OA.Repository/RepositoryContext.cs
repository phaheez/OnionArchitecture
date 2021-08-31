using System;
using Microsoft.EntityFrameworkCore;
using OA.DataAccess;

namespace OA.Repository
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions options): base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
    }
}
