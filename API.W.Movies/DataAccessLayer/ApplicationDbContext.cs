using API.W.Movies.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace API.W.Movies.DataAccessLayer
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        //Sección para crear el dbset de las entidades o modelos
        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
