using BackEnd.Data.Contracts.Requests;
using BackEnd.Data.Contracts.Responses;
using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data.Services.IServices
{
    public interface IVertinimasService : IService<Vertinimas>
    {
        Task<IList<IVertinimasResponse>> GetAllVertinimas();
        Task<IVertinimasResponse> GetVertinimas(int id);
        Task<Vertinimas> AddVertinimas(VertinimasRequest vertinimasRequest);
        Task<Vertinimas> UpdateVertinimas(int id, VertinimasRequest vertinimasRequest);
        Task<Vertinimas> DeleteVertinimas(int id);
    }
}
