using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data.Contracts.Requests
{
    public class VertinimasRequest
    {
        public int Vertinimas1 { get; set; }
        public int idRecenzija { get; set; }
        public int idNaudotojas { get; set; }
    }
}
