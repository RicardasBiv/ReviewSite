using BackEnd.Data.Contracts.DataTransferObjects;
using BackEnd.Data.Contracts.Responses;
using BackEnd.Data.Repositories.IRepositories;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace BackEnd.Data.Repositories
{
    public class RecenzijaRepository : BaseRepository<Recenzija,ApplicationDbContext>, IRecenzijaRepository
    {
        public RecenzijaRepository(ApplicationDbContext context) : base(context) { }
        public async Task<IList<ReviewResponse>> GetAllReviews()
        {
            Vertinimas defaulttest = new Vertinimas { IdNaudotojas = 1, Vertinimas1 = 0, IdRecenzija = 2 };
            return await context.Recenzija
                                    .Select(x => new ReviewResponse()
                                    {
                                        Id = x.Id,
                                        Pavadinimas = x.Pavadinimas,
                                        Aprasymas = x.Aprasymas,
                                        KritikoVertinimas = x.KritikoVertinimas,
                                        Rasytojas = new UserDto()
                                        {
                                            Email = x.RasytojasNavigation.Email,
                                            Username = x.RasytojasNavigation.UserName
                                        },
                                        Tipas = new TypeDto()
                                        {
                                            Name = x.TipasNavigation.Tipas1
                                        },
                                        Zanras = new GenreDto()
                                        {
                                            Name = x.ZanrasNavigation.Name
                                        },
                                        Vertinimas = 0
                                        //Vertinimas = x.Vertinimas.DefaultIfEmpty().Average(d => d.Vertinimas1)
                                    }).ToListAsync();
        }
        public async Task<IList<ReviewResponse>> GetAllYourReviews(int id)
        {
            
            Vertinimas defaulttest = new Vertinimas { IdNaudotojas = 1, Vertinimas1 = 0, IdRecenzija = 2 };
            return await context.Recenzija
                                    .Where(x => x.RasytojasNavigation.Id == id)
                                    .Select(x => new ReviewResponse()
                                    {
                                        Id = x.Id,
                                        Pavadinimas = x.Pavadinimas,
                                        Aprasymas = x.Aprasymas,
                                        KritikoVertinimas = x.KritikoVertinimas,
                                        Rasytojas = new UserDto()
                                        {
                                            Email = x.RasytojasNavigation.Email,
                                            Username = x.RasytojasNavigation.UserName
                                        },
                                        Tipas = new TypeDto()
                                        {
                                            Name = x.TipasNavigation.Tipas1
                                        },
                                        Zanras = new GenreDto()
                                        {
                                            Name = x.ZanrasNavigation.Name
                                        },
                                        Vertinimas = 0
                                        //Vertinimas = x.Vertinimas.DefaultIfEmpty().Average(d => d.Vertinimas1)
                                    }).ToListAsync();
        }



        public async Task<ReviewResponse> GetReview(int id)
        {
            return await context.Recenzija
                                     .Where(x => x.Id == id)
                                     .Select(x => new ReviewResponse()
                                     {
                                         Id = x.Id,
                                         Pavadinimas = x.Pavadinimas,
                                         Aprasymas = x.Aprasymas,
                                         KritikoVertinimas = x.KritikoVertinimas,
                                         Rasytojas = new UserDto()
                                         {
                                             Email = x.RasytojasNavigation.Email,
                                             Username = x.RasytojasNavigation.UserName
                                         },
                                         Tipas = new TypeDto()
                                         {
                                             Name = x.TipasNavigation.Tipas1
                                         },
                                         Zanras = new GenreDto()
                                         {
                                             Name = x.ZanrasNavigation.Name
                                         },
                                         Vertinimas = 0
                                     }).FirstOrDefaultAsync();
        }

       
    }
}
