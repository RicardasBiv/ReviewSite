using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BackEnd.Data.Configurations
{
    public class KomentarasConfiguration : IEntityTypeConfiguration<Komentaras>
    {
        public void Configure(EntityTypeBuilder<Komentaras> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
