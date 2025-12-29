using LibreriaLogicaNegocio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.EF.Config
{
    public class ExpenseConfig : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.ToTable("Expenses");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.OwnsOne(e => e.Name, nb =>
            {
                nb.Property(p => p.Value)
                  .HasColumnName("Name")
                  .IsRequired()
                  .HasMaxLength(100);
            });
            builder.OwnsOne(e => e.Description, db =>
            {
                db.Property(p => p.Value)
                  .HasColumnName("Description")
                  .IsRequired()
                  .HasMaxLength(200);
            });
        }
    }
}


