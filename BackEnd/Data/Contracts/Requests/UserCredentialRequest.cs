using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data.Contracts.Requests
{
    public class UserCredentialRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
