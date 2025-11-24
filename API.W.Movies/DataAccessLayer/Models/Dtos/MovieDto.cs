using System.ComponentModel.DataAnnotations;

namespace API.W.Movies.DataAccessLayer.Models.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        [Required(ErrorMessage = "El nombre de la pelicula es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El número máximo de caracteres es de 100.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "La duración de la pelicula es obligatoria.")]
        public int Duration { get; set;}

        public string? Description { get; set;}

        [Required(ErrorMessage = "La clasificación de la pelicula es obligatoria.")]
        [MaxLength(10, ErrorMessage = "El número máximo de caracteres es de 10.")]
        public string Clasification { get; set;}
    }
}