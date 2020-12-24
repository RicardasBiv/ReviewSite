using BackEnd.Data.Repositories.IRepositories;
using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data.Repositories
{
    public class ZanraiRepository : BaseRepository<Zanrai, ApplicationDbContext>, IZanraiRepository
    {
        public ZanraiRepository(ApplicationDbContext context) : base(context) { }
    }
}
