using BackEnd.Data.Contracts.Responses;
using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data.Repositories.IRepositories
{
    public interface IRecenzijaRepository : IRepository<Recenzija>
    {
        public Task<IList<ReviewResponse>> GetAllReviews();
        public Task<IList<ReviewResponse>> GetAllYourReviews(int id);
        public Task<ReviewResponse> GetReview(int id);
    }
}
