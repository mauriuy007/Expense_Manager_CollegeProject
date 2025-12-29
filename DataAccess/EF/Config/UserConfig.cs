using LibreriaLogicaNegocio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.EF.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.HasDiscriminator<string>("UserType")
                .HasValue<User>("Base")
                .HasValue<Administrator>("Administrator")
                .HasValue<Employee>("Employee")
                .HasValue<Manager>("Manager");
            builder.OwnsOne(e => e.Name, nb =>
            {
                nb.Property(p => p.Value)
                  .HasColumnName("Name")
                  .IsRequired()
                  .HasMaxLength(100);
            });
            builder.OwnsOne(e => e.LastName, db =>
            {
                db.Property(p => p.Value)
                  .HasColumnName("LastName")
                  .IsRequired()
                  .HasMaxLength(200);
            });
            builder.OwnsOne(e => e.Email, db =>
            {
                db.Property(p => p.Value)
                  .HasColumnName("Email")
                  .IsRequired()
                  .HasMaxLength(200);
            });
            builder.OwnsOne(e => e.Password, db =>
            {
                db.Property(p => p.Value)
                  .HasColumnName("Password")
                  .IsRequired()
                  .HasMaxLength(200);
            });
            builder.HasOne(t => t.Team)
                .WithMany()
                .HasForeignKey(p => p.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
