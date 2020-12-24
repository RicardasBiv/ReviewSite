using BackEnd.Data.Contracts.Responses;
using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data.Repositories.IRepositories
{
    public interface IVertinimasRepository : IRepository<Vertinimas>
    {
        public Task<IList<IVertinimasResponse>> GetAllVertinimas();
        public Task<IVertinimasResponse> GetVertinimas(int id);
    }
}
