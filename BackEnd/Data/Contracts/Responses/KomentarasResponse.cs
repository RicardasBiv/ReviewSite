using BackEnd.Data.Contracts.DataTransferObjects;
using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data.Contracts.Responses
{
    public class KomentarasResponse
    {
        public int Id { get; set; }
        public string Komentaras { get; set; }
        public GradeDto Vertinimas { get; set; }
    }
}
