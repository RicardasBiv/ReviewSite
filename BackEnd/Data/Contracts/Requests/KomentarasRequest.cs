using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data.Contracts.Requests
{
    public class KomentarasRequest
    {
        public string Komentaras1 { get; set; }
        public int VertinimasId { get; set; }
    }
}
