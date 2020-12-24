using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Data.Configurations
{
    public class RecenzijaConfiguration : IEntityTypeConfiguration<Recenzija>
    {
        public void Configure(EntityTypeBuilder<Recenzija> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Vertinimas)
                .WithOne(x => x.IdRecenzijaNavigation)
                .HasForeignKey(x => x.IdRecenzija)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
