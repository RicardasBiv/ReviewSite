using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BackEnd.Models
{
    public class Naudotojas : IdentityUser<int>, IEntity
    {
        public virtual ICollection<Recenzija> Recenzija { get; set; }
        public virtual ICollection<Vertinimas> Vertinimas { get; set; }
    }
}
