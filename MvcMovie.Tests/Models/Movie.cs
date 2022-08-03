using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MvcMovie.Tests.Models
{
    /// <summary>
    /// Movie Model
    /// 속성 - ID / Title / ReleaseDate / Genre / Price / Rating
    /// 조건 - property 별 명시
    /// </summary>
    public class Movie
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [StringLength(5)]
        public string Rating { get; set; }




    }

    
    /// <summary>
    /// MovieDbContext Model
    /// </summary>
    public class MovieDBContext : DbContext
    { 
        public DbSet<Movie> Movies { get; set; }
    }
}