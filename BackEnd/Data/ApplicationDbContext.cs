using BackEnd.Data.Configurations;
using BackEnd.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data
{
    public class ApplicationDbContext : IdentityDbContext<Naudotojas, Role, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Komentaras> Komentaras { get; set; }
        public virtual DbSet<Naudotojas> Naudotojas { get; set; }
        public virtual DbSet<Recenzija> Recenzija { get; set; }
        public virtual DbSet<Tipas> Tipas { get; set; }
        public virtual DbSet<Vertinimas> Vertinimas { get; set; }
        public virtual DbSet<Zanrai> Zanrai { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var komentarasbuilder = modelBuilder.ApplyConfiguration(new KomentarasConfiguration());
            var naudotojasbuilder = modelBuilder.ApplyConfiguration(new NaudotojasConfiguration());
            var recenzijabuilder = modelBuilder.ApplyConfiguration(new RecenzijaConfiguration());
            var tipasBuilder = modelBuilder.ApplyConfiguration(new TipasConfiguration());
            var vertinimasbuilder = modelBuilder.ApplyConfiguration(new VertinimasConfiguration());
            var zanraibuilder = modelBuilder.ApplyConfiguration(new ZanraiConfiguration());

            base.OnModelCreating(modelBuilder);

            naudotojasbuilder.Entity<Naudotojas>().HasData(
                new Naudotojas { Id = 1, UserName = "admin", Email = "admin@admin.com", PasswordHash = "" },
                new Naudotojas { Id = 2, UserName = "Writer", Email = "writer@writer.com", PasswordHash = "" },
                new Naudotojas { Id = 3, UserName = "User", Email = "user@user.com", PasswordHash = "" },
                new Naudotojas { Id = 4, UserName = "user2", Email = "user2@user2.com", PasswordHash = "" }
                );

            zanraibuilder.Entity<Zanrai>().HasData(
                new Zanrai { Id = 1, Name = "Veiksmo" },
                new Zanrai { Id = 2, Name = "Animacinis" },
                new Zanrai { Id = 3, Name = "Fantastinis" },
                new Zanrai { Id = 4, Name = "Nuotykių" },
                new Zanrai { Id = 5, Name = "Siaubo" },
                new Zanrai { Id = 6, Name = "Trileris" },
                new Zanrai { Id = 7, Name = "Romantinis" }
                );
            tipasBuilder.Entity<Tipas>().HasData(
                new Tipas { Id = 1, Tipas1 = "Knyga" },
                new Tipas { Id = 2, Tipas1 = "Filmas" },
                new Tipas { Id = 3, Tipas1 = "Serialas" }
                );

            recenzijabuilder.Entity<Recenzija>().HasData(
                new Recenzija { Id = 1, Pavadinimas = "Inception", Tipas = 1, Zanras = 1, Aprasymas = "Aprasymas", RasytojasId = 2, KritikoVertinimas = 5 },
                new Recenzija { Id = 2, Pavadinimas = "Antras", Tipas = 2, Zanras = 1, Aprasymas = "Aprasfasfdasdfymas", RasytojasId = 2, KritikoVertinimas = 8 },
                new Recenzija { Id = 3, Pavadinimas = "Trecias", Tipas = 2, Zanras = 1, Aprasymas = "Aprassadfasdfymas", RasytojasId = 2, KritikoVertinimas = 7 },
                new Recenzija { Id = 4, Pavadinimas = "Ketvirtas", Tipas = 2, Zanras = 1, Aprasymas = "Aprsdfasdfasdfasymas", RasytojasId = 2, KritikoVertinimas = 10 },
                new Recenzija { Id = 5, Pavadinimas = "Penktas", Tipas = 2, Zanras = 1, Aprasymas = "Aprassadfasdfymas", RasytojasId = 2, KritikoVertinimas = 9 },
                new Recenzija { Id = 6, Pavadinimas = "Haris Poteris", Tipas = 2, Zanras = 1, Aprasymas = "Apdfasdfsadfrasymas", RasytojasId = 2, KritikoVertinimas = 7 },
                new Recenzija { Id = 7, Pavadinimas = "Fast and furiuos", Tipas = 2, Zanras = 1, Aprasymas = "Aprassdfasdfsaymas", RasytojasId = 2, KritikoVertinimas = 8 }
                );

            vertinimasbuilder.Entity<Vertinimas>().HasData(
                
                new Vertinimas { Id = 1, IdNaudotojas = 3, IdRecenzija = 1, Vertinimas1 = 10},
                new Vertinimas { Id = 2, IdNaudotojas = 3, IdRecenzija = 2, Vertinimas1 = 10 },
                new Vertinimas { Id = 3, IdNaudotojas = 3, IdRecenzija = 2, Vertinimas1 = 5 },
                new Vertinimas { Id = 4, IdNaudotojas = 4, IdRecenzija = 3, Vertinimas1 = 5 },
                new Vertinimas { Id = 5, IdNaudotojas = 4, IdRecenzija = 4, Vertinimas1 = 7 },
                new Vertinimas { Id = 6, IdNaudotojas = 4, IdRecenzija = 5, Vertinimas1 = 10 }
                );
            komentarasbuilder.Entity<Komentaras>().HasData(
                new Komentaras { Id = 1, Komentaras1 = "komentaras", VertinimasId = 1},
                new Komentaras { Id = 2, Komentaras1 = "komentaras", VertinimasId = 2 },
                new Komentaras { Id = 3, Komentaras1 = "komentaras", VertinimasId = 3 },
                new Komentaras { Id = 4, Komentaras1 = "komentaras", VertinimasId = 4 },
                new Komentaras { Id = 5, Komentaras1 = "komentaras", VertinimasId = 5 },
                new Komentaras { Id = 6, Komentaras1 = "komentaras", VertinimasId = 6 }
                );
        }


    }
}
