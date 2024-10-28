using Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    /*
     * We tell Entity FrameWork about properties that order Owns
     * and we also will do some configuration for enum
     */
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(o => o.ShipToAddress, a =>
            {
                a.WithOwner();
                //go in property from here, we will rely Address dto
            });
            builder.Navigation(a => a.ShipToAddress).IsRequired();
            builder.Property(s => s.Status)
                .HasConversion( // get our enum to string rather than int which will be returned by default
                    o => o.ToString(),
                    o => (OrderSatus)Enum.Parse(typeof(OrderSatus), o)
                );
            /*
             * if we delete an order we will delete and order item
             * order one to many relationship with order items
             */
            builder.HasMany(o => o.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}
