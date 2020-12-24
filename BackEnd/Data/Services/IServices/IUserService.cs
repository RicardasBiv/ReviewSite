using BackEnd.Data.Contracts.Requests;
using BackEnd.Data.Contracts.Responses;
using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data.Services.IServices
{
    public interface IUserService : IService<Naudotojas>
    {
        Task<IList<UserResponse>> GetUsers();
        Task<UserResponse> GetUser(int id);
        Task<Naudotojas> AddUser(AddUserRequest userRequest);
        Task<Naudotojas> UpdateUser(int id, UpdateUserRequest userRequest);
        Task<Naudotojas> DeleteUser(int id);
    }
}
