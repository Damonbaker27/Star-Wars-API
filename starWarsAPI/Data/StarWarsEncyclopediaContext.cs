using Microsoft.EntityFrameworkCore;
using starWarsAPI.Models.Entities;

namespace starWarsAPI.Data
{
    public class StarWarsEncyclopediaContext : DbContext
    {

        public StarWarsEncyclopediaContext(DbContextOptions options) : base(options) { }

        public DbSet<Character>Characters {get; set;}

        public DbSet<Homeworld> Homeworlds { get; set;}

        public DbSet<StarShip> StarShips { get; set;}

        public DbSet<Film> Films { get; set; }

        public DbSet<CharacterFilm> CharacterFilms { get; set; }

        public DbSet<CharacterStarship> CharacterStarships { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CharacterStarship>()
                .HasKey(cs => new { cs.CharacterId, cs.StarshipId });

            modelBuilder.Entity<CharacterStarship>()
                .HasOne(cs => cs.Character)
                .WithMany(cs => cs.StarShip)
                .HasForeignKey(cs => cs.CharacterId);

            modelBuilder.Entity<CharacterStarship>()
                .HasOne(cs => cs.StarShip)
                .WithMany(cs => cs.Character)
                .HasForeignKey(cs => cs.StarshipId);

            modelBuilder.Entity<CharacterFilm>()
                .HasKey(cf => new { cf.CharacterId, cf.FilmId });

            modelBuilder.Entity<CharacterFilm>()
                .HasOne(cf => cf.Character)
                .WithMany(cf => cf.Film)
                .HasForeignKey(cf => cf.CharacterId);

            modelBuilder.Entity<CharacterFilm>()
                .HasOne(cf => cf.Film)
                .WithMany(cf => cf.Character)
                .HasForeignKey(cf => cf.FilmId);

        }



    }
}
