using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace starWarsAPI.Models.Entities
{
    public class Character
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CharacterId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string? FullName { get; set; }

        [ForeignKey("HomeWorld")]
        public int HomeWorldId { get; set; }

        public int? Mass { get; set; }

        public string? HairColor { get; set; }

        public string? SkinColor { get; set; }

        public string? EyeColor { get; set; }

        public string? BirthYear { get; set; }

        public string? ImagePath { get; set; }

        //navigational properties
        public virtual Homeworld HomeWorld { get; set; }

        public virtual ICollection<CharacterFilm> Film { get; set; }

        public virtual ICollection<CharacterStarship> StarShip { get; set; }

    }


    public class Homeworld
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HomeWorldId { get; set; }

        [Required]
        public string? Name { get; set; }

        public int? RotationPeriod { get; set; }

        public int? OrbitalPeriod { get; set; }

        public double? Diameter { get; set; }

        public string? Climate { get; set; }

        public string? Gravity { get; set; }

        public string? Terrain { get; set; }

        public string? SurfaceWater { get; set; }

        public string? Population { get; set; }

        public string? ImagePath { get; set; }


        // Navigational properties
        public virtual ICollection<Character> Character { get; set; }

    }


    public class Film
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FilmId { get; set; }

        [Required]
        public string? Title { get; set; }

        public string? OpeningCrawl { get; set; }

        public string? Director { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string? ImagePath { get; set; }

        //Navigational properties
        public virtual ICollection<CharacterFilm> Character { get; set; }

    }


    public class StarShip
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StarshipId { get; set; }

        [Required]
        public string? Name { get; set; }

        public string? Model { get; set; }

        public string? Manufacturer { get; set; }

        public int? Cost { get; set; }

        public int? Length { get; set; }

        public decimal? MaxAtmosphereSpeed { get; set; }

        public int? Crew { get; set; }

        public int? Passengers { get; set; }

        public string? StarShipClass { get; set; }

        public string? ImagePath { get; set; }

        //Navigational properties
        public virtual ICollection<CharacterStarship> Character { get; set; }

    }

    public class CharacterStarship
    {
        public int? StarshipId { get; set; }

        public int? CharacterId { get; set; }

        //navigational properties
        public StarShip? StarShip { get; set; }

        public Character? Character { get; set; }
    }

    public class CharacterFilm
    {
        public int FilmId { get; set; }

        public int CharacterId { get; set; }

        //navigational properties
        public Film? Film { get; set; }

        public Character? Character { get; set; }

    }
}
