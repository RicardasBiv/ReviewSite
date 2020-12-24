using BackEnd.Data.Contracts.DataTransferObjects;
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
    public class KomentarasRepository : BaseRepository<Komentaras, ApplicationDbContext>, IKomentarasRepository
    {
        public KomentarasRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IList<KomentarasResponse>> GetAllKomentarai(int Recenzijaid)
        {
            return await context.Komentaras
                                    .Where(x => x.Vertinimas.IdRecenzijaNavigation.Id== Recenzijaid)
                                    .Select(x => new KomentarasResponse()
                                    {
                                        Id = x.Id,
                                        Komentaras = x.Komentaras1,
                                        Vertinimas = new GradeDto()
                                        {
                                            Vertinimas1 = x.Vertinimas.Vertinimas1,
                                            Naudotojas = x.Vertinimas.IdNaudotojasNavigation.UserName
                                        }
                                    }).ToListAsync();
        }

        public async Task<KomentarasResponse> GetKomentaras(int id)
        {
            return await context.Komentaras
                                    .Where(x => x.Id == id)
                                    .Select(x => new KomentarasResponse()
                                    {
                                        Id = x.Id,
                                        Komentaras = x.Komentaras1,
                                        Vertinimas = new GradeDto()
                                        {
                                            Vertinimas1 = x.Vertinimas.Vertinimas1,
                                            Naudotojas = x.Vertinimas.IdNaudotojasNavigation.UserName
                                        }
                                    }).FirstOrDefaultAsync();
        }
    }
}
