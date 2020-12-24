using BackEnd.Data.Contracts.Responses;
using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data.Repositories.IRepositories
{
    public interface IUserRepository : IRepository<Naudotojas>
    {
        public Task<IList<UserResponse>> GetAllUsers();
        public Task<UserResponse> GetUser(int id);
    }
}
