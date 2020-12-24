using BackEnd.Data.Contracts.Requests;
using BackEnd.Data.Contracts.Responses;
using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data.Services.IServices
{
    public interface IKomentarasService : IService<Komentaras>
    {
        Task<IList<KomentarasResponse>> GetAllKomentarai(int recenzijuid);
        Task<KomentarasResponse> GetKomentaras(int id);
        Task<Komentaras> AddKomentaras(KomentarasRequest komentarasRequest);
        Task<Komentaras> UpdateKomentaras(int id, KomentarasRequest komentarasRequest);
        Task<Komentaras> DeleteKomentaras(int id);
    }
}
