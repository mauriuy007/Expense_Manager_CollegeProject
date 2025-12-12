using LibreriaLogicaNegocio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.EF.Config
{
    public class UniquePaymentConfig : IEntityTypeConfiguration<UniquePayment>
    {
        public void Configure(EntityTypeBuilder<UniquePayment> builder)
        {
            builder.OwnsOne(r => r.PayDate, nb =>
            {
                nb.Property(p => p.Value)
                  .HasColumnName("PayDate")
                  .IsRequired();
            });
            builder.OwnsOne(r => r.BillNumber, nb =>
            {
                nb.Property(p => p.Value)
                  .HasColumnName("BillNumber")
                  .IsRequired();
            });
        }
    }
}

