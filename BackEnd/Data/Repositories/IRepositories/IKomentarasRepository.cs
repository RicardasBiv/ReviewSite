using BackEnd.Data.Contracts.Responses;
using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data.Repositories.IRepositories
{
    public interface IKomentarasRepository : IRepository<Komentaras>
    {
        public Task<IList<KomentarasResponse>> GetAllKomentarai(int recenzijaid);
        public Task<KomentarasResponse> GetKomentaras(int id);
    }
}
