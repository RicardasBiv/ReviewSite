using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data.Contracts.Requests
{
    public class ReviewUpdateRequest
    {
        public string Pavadinimas { get; set; }
        public string Aprasymas { get; set; }
        public int Tipas { get; set; }
        public int Zanras { get; set; }
        public int KritikoVertinimas { get; set; }
    }
}
