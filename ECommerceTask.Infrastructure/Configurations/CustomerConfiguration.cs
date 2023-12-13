using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ECommerceTask.Domain.Entities;

namespace ECommerceTask.Infrastructure.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(200);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(300);
        }
    }

}
