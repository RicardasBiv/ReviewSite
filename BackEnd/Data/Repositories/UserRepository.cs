using BackEnd.Data.Contracts.Responses;
using BackEnd.Data.Repositories.IRepositories;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data.Repositories
{
    public class UserRepository : BaseRepository<Naudotojas, ApplicationDbContext>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }
         public async Task<IList<UserResponse>> GetAllUsers()
         {
             return await context.Users
                 .Select(x => new UserResponse()
                 {
                     Email = x.Email,
                     Id = x.Id,
                     Username = x.UserName,
                     
                 }).ToListAsync();
         }

         public async Task<UserResponse> GetUser(int id)
         {
             return await context.Users
                 .Where(x => x.Id == id)
                 .Select(x => new UserResponse()
                 {
                     Email = x.Email,
                     Id = x.Id,
                     Username = x.UserName
                  
                 }).FirstOrDefaultAsync();
         }
    }
}
