using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data.Contracts.Responses
{
    public class IVertinimasResponse
    {
        public int Id { get; set; }
        public int Vertinimas1 { get; set; }
        public int IdRecenzija { get; set; }
    }
}
