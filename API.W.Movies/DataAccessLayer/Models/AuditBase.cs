using System.ComponentModel.DataAnnotations;

namespace API.W.Movies.DataAccessLayer.Models
{
    public class AuditBase
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual DateTime CreatedDate { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
    }
}
