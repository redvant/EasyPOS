using Domain.Customers;
using Domain.ValueObjects;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        
        builder.HasKey(customer => customer.Id);

        builder.Property(customer => customer.Id)
            .HasConversion(id => id.Value, value => new CustomerId(value));

        builder.Property(customer => customer.Name)
            .HasMaxLength(50);

        builder.Property(customer => customer.LastName)
            .HasMaxLength(50);

        builder.Ignore(customer => customer.FullName);

        builder.Property(customer => customer.Email)
            .HasMaxLength(255);

        builder.HasIndex(customer => customer.Email)
            .IsUnique();

        builder.Property(customer => customer.PhoneNumber)
            .HasConversion(phoneNumber => phoneNumber.Value, value => PhoneNumber.Create(value)!)
            .HasMaxLength(9);

        builder.OwnsOne(customer => customer.Address, addressBuilder =>
        {
            addressBuilder.Property(a => a.Line1)
                .HasMaxLength(50);

            addressBuilder.Property(a => a.Line2)
                .HasMaxLength(50)
                .IsRequired(false);

            addressBuilder.Property(a => a.City)
                .HasMaxLength(20);

            addressBuilder.Property(a => a.ZipCode)
                .HasMaxLength(10)
                .IsRequired(false);

            addressBuilder.Property(a => a.State)
                .HasMaxLength(20);

            addressBuilder.Property(a => a.Country)
                .HasMaxLength(20);
        });

        builder.Property(customer => customer.Active);
    }
}
