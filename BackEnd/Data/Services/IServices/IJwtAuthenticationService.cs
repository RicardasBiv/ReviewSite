using BackEnd.Data.Contracts.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data.Services.IServices
{
    public interface IJwtAuthenticationService
    {
        Task<string> Authenticate(UserCredentialRequest userCredentialRequest);
    }
}
