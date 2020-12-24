using BackEnd.Data.Repositories.IRepositories;
using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data.Repositories
{
    public class TipasRepository : BaseRepository<Tipas, ApplicationDbContext>, ITipasRepository
    {
        public TipasRepository(ApplicationDbContext context) : base(context) { }
    }
}
