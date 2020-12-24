using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class Komentaras : IEntity
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Komentaras1 { get; set; }
        [Required]
        public int? VertinimasId { get; set; }
        public virtual Vertinimas Vertinimas { get; set; }
    }
}
