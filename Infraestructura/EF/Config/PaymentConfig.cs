using LibreriaLogicaNegocio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.EF.Config
{
    public class PaymentConfig : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.HasDiscriminator<string>("PaymentType")
                   .HasValue<Payment>("Base")
                   .HasValue<RecurringPayment>("Recurring")
                   .HasValue<UniquePayment>("Unique");
            builder.OwnsOne(e => e.PaymentMethod, nb =>
            {
                nb.Property(p => p.Value)
                  .HasColumnName("PaymentMethod")
                  .IsRequired()
                  .HasMaxLength(100);
            });
            builder.OwnsOne(e => e.Description, nb =>
            {
                nb.Property(p => p.Value)
                  .HasColumnName("Description")
                  .IsRequired()
                  .HasMaxLength(100);
            });
            builder.OwnsOne(e => e.Amount, nb =>
            {
                nb.Property(p => p.Value)
                  .HasColumnName("Amount")
                  .IsRequired()
                  .HasMaxLength(100);
            });
            builder.HasOne(p => p.Expense)
                .WithMany()
                .HasForeignKey(p => p.ExpenseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

