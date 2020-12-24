using BackEnd.Data.Contracts.DataTransferObjects;
using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data.Contracts.Responses
{
    public class ReviewResponse
    {
        public int Id { get; set; }
        public string Pavadinimas { get; set; }
        public string Aprasymas { get; set; }
        public UserDto Rasytojas { get; set; }
        public TypeDto Tipas { get; set; }
        public GenreDto Zanras { get; set; }
        public int KritikoVertinimas { get; set; }
        public double Vertinimas { get; set; }
}
}
