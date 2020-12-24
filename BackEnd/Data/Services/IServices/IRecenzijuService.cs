using BackEnd.Data.Contracts.Requests;
using BackEnd.Data.Contracts.Responses;
using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data.Services.IServices
{
    public interface IRecenzijuService : IService<Recenzija>
    {
        Task<IList<ReviewResponse>> GetReviews();
        Task<IList<ReviewResponse>> GetYourReviews(int id);
        Task<ReviewResponse> GetReview(int id);
        Task<Recenzija> AddReview(ReviewRequest reviewRequest);
        Task<Recenzija> UpdateReview(int id, ReviewUpdateRequest reviewRequest);
        Task<Recenzija> DeleteReview(int id);
    }
}
