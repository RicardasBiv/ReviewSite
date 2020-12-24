using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data.Contracts.DataTransferObjects
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
