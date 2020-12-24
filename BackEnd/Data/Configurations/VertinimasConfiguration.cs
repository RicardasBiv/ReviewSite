using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackEnd.Data.Configurations
{
    public class VertinimasConfiguration : IEntityTypeConfiguration<Vertinimas>
    {
        public void Configure(EntityTypeBuilder<Vertinimas> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Komentaras)
                .WithOne(x => x.Vertinimas)
                .HasForeignKey(x => x.VertinimasId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
