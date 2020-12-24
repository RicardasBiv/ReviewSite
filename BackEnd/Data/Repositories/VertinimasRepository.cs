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
    public class VertinimasRepository : BaseRepository<Vertinimas, ApplicationDbContext>, IVertinimasRepository
    {
        public VertinimasRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IList<IVertinimasResponse>> GetAllVertinimas()
        {
            return await context.Vertinimas
                                    .Select(x => new IVertinimasResponse()
                                    {
                                        Id = x.Id,
                                        Vertinimas1 = x.Vertinimas1,
                                        IdRecenzija = x.IdRecenzija
                                        
                                    }).ToListAsync();
        }

        public async Task<IVertinimasResponse> GetVertinimas(int id)
        {
            return await context.Vertinimas
                                    .Where(x => x.Id == id)
                                    .Select(x => new IVertinimasResponse()
                                    {
                                        Id = x.Id,
                                        Vertinimas1 = x.Vertinimas1,
                                        IdRecenzija = x.IdRecenzija
                                    }).FirstOrDefaultAsync();
        }
    }
}
