using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class Vertinimas : IEntity
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int Vertinimas1 { get; set; }
        [Required]
        public int IdNaudotojas { get; set; }
        public virtual Naudotojas IdNaudotojasNavigation { get; set; }
        [Required]
        public int IdRecenzija { get; set; }
        public virtual Recenzija IdRecenzijaNavigation { get; set; }

        public virtual ICollection<Komentaras> Komentaras { get; set; }
    }
}
