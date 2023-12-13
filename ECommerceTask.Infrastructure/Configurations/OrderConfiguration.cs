using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceTask.Domain.Aggregates.Order;

namespace ECommerceTask.Infrastructure.Configurations
{

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);
        builder.Property(o => o.CreatedAt).IsRequired();
        builder.HasMany(o => o.OrderItems).WithOne().HasForeignKey(oi => oi.OrderId).OnDelete(DeleteBehavior.Cascade);
    }
}

}
