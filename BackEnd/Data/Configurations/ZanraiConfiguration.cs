using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Data.Configurations
{
    public class ZanraiConfiguration : IEntityTypeConfiguration<Zanrai>
    {
        public void Configure(EntityTypeBuilder<Zanrai> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Recenzija)
                .WithOne(x => x.ZanrasNavigation)
                .HasForeignKey(x => x.Zanras)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
