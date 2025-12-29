using LibreriaLogicaNegocio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.EF.Config
{
    public class LogConfig : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("Logs");

            builder.HasKey(l => l.Id);

            builder.Property(l => l.Id)
                .ValueGeneratedOnAdd();

            builder.Property(l => l.Message)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(l => l.Operation)
                .IsRequired();

            builder.Property(l => l.DateTime)
                .IsRequired();

            builder.HasOne(l => l.Expense)
                .WithMany()
                .HasForeignKey(l => l.ExpenseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(l => l.User)
                .WithMany()
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
