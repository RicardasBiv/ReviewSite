using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd.Models
{
    public class Recenzija : IEntity
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Pavadinimas { get; set; }
        public string Aprasymas { get; set; }
        public int KritikoVertinimas { get; set; }


        [Required]
        public int RasytojasId { get; set; }
        public virtual Naudotojas RasytojasNavigation { get; set; }
        [Required]
        public int Tipas { get; set; }
        public virtual Tipas TipasNavigation { get; set; }
        [Required]
        public int Zanras { get; set; }
        public virtual Zanrai ZanrasNavigation { get; set; }
        public virtual ICollection<Vertinimas> Vertinimas { get; set; }
    }
}
