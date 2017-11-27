
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.Data.EntityConfig
{
    class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasIndex(b => new {b.UserId, b.BankAccountId, b.CreditCardId}).IsUnique();

            builder.HasOne(b => b.User)
                .WithMany(u => u.PaymentMethods)
                .HasForeignKey(b => b.UserId);

            builder.HasOne(b => b.BankAccount)
                .WithOne(ba => ba.PaymentMethod)
                .HasForeignKey<PaymentMethod>(b => b.BankAccountId);

            builder.HasOne(b => b.CreditCard)
                .WithOne(c => c.PaymentMethod)
                .HasForeignKey<PaymentMethod>(b => b.CreditCardId);
        }
    }
}
