using System;
// DataAnnotations 
// : 어노테이션을 활용해서 클래스나 메소드에대한 속성을 주입해준다.
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace MVCTest.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }



        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }


    }

    public class MovieDBContext : DbContext
    { 
        public DbSet<Movie> Movies { get; set; }

    }
}