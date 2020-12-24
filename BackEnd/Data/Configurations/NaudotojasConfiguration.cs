using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Data.Configurations
{
    public class NaudotojasConfiguration : IEntityTypeConfiguration<Naudotojas>
    {
        public void Configure(EntityTypeBuilder<Naudotojas> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Recenzija)
                .WithOne(x => x.RasytojasNavigation)
                .HasForeignKey(x => x.RasytojasId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Vertinimas)
                .WithOne(x => x.IdNaudotojasNavigation)
                .HasForeignKey(x => x.IdNaudotojas)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
