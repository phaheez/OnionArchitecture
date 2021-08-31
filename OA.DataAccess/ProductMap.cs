using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OA.DataAccess
{
    public class ProductMap
    {
        public ProductMap(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.HasKey(p => p.Id);
            entityBuilder.Property(p => p.ProductName).IsRequired();
            entityBuilder.HasOne(p => p.ProductDetails)
                .WithOne(p => p.Product)
                .HasForeignKey<ProductDetails>(x => x.Id);
        }
    }
}
