using LibreriaLogicaNegocio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.EF.Config
{
    public class RecurringPaymentConfig : IEntityTypeConfiguration<RecurringPayment>
    {
        public void Configure(EntityTypeBuilder<RecurringPayment> builder)
        {
            builder.OwnsOne(r => r.DateFrom, nb =>
            {
                nb.Property(p => p.Value)
                  .HasColumnName("DateFrom")
                  .IsRequired();
            });

            builder.OwnsOne(r => r.DateTill, nb =>
            {
                nb.Property(p => p.Value)
                  .HasColumnName("DateTill")
                  .IsRequired();
            });
        }
    }
}
