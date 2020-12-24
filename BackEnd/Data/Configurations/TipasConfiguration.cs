using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Data.Configurations
{
    public class TipasConfiguration : IEntityTypeConfiguration<Tipas>
    {
        public void Configure(EntityTypeBuilder<Tipas> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Recenzija)
                .WithOne(x => x.TipasNavigation)
                .HasForeignKey(x => x.Tipas)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
