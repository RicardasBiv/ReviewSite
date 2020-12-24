using BackEnd.Data.Contracts.Requests;
using BackEnd.Data.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data.Services
{
    public class JwtAuthenticationService : IJwtAuthenticationService
    {
        public ApplicationDbContext _applicationDbContext;

        public JwtAuthenticationService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Task<string> Authenticate(UserCredentialRequest userCredentialRequest)
        {
            throw new NotImplementedException();
        }
    }
}
