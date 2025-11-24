using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.W.Movies.DataAccessLayer.Models
{
    public class Movie : AuditBase
    {
        [Required]
        [Display(Name="Nombre de la pelicula")]
        public string Name { get; set;}

        [Required]
        [Display(Name="Duracion de la pelicula")]
        public int Duration { get; set;}

        [Display(Name="Descripción de la pelicula")]
        public string? Description { get; set;}

        [Required]
        [Display(Name="Clasificación de la pelicula")]
        public string Clasification { get; set;}
    }
}