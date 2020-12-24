using AutoMapper;
using BackEnd.Data.Contracts.Requests;
using BackEnd.Data.Contracts.Responses;
using BackEnd.Data.Repositories.IRepositories;
using BackEnd.Data.Services.IServices;
using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data.Services
{
    public class RecenzijaService : BaseService<Recenzija, IRecenzijaRepository>, IRecenzijuService
    {
        private readonly IRecenzijaRepository _recenzijaRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RecenzijaService(IRecenzijaRepository recenzijaRepository,
                                  IUserRepository userRepository,
                                  IMapper mapper) : base(recenzijaRepository)
        {
            _recenzijaRepository = recenzijaRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Recenzija> AddReview(ReviewRequest reviewRequest)
        {
            var review = _mapper.Map<Recenzija>(reviewRequest);
            var reviewAdded = await _recenzijaRepository.Add(review);

            return reviewAdded;
        }

        public async Task<Recenzija> DeleteReview(int id)
        {
            var reviewDeleted = await _recenzijaRepository.Delete(id);

            return reviewDeleted;
        }

        public async Task<ReviewResponse> GetReview(int id)
        {
            return await _recenzijaRepository.GetReview(id);
        }
        public async Task<IList<ReviewResponse>> GetYourReviews(int id)
        {
            return await _recenzijaRepository.GetAllYourReviews(id);
        }
        public async Task<IList<ReviewResponse>> GetReviews()
        {
            return await _recenzijaRepository.GetAllReviews();
        }
        public async Task<Recenzija> UpdateReview(int id, ReviewUpdateRequest reviewrequest)
        {
            var recenzija = await _recenzijaRepository.Get(id);
            recenzija.Pavadinimas = reviewrequest.Pavadinimas;
            recenzija.Aprasymas = reviewrequest.Aprasymas;
            recenzija.KritikoVertinimas = reviewrequest.KritikoVertinimas;
            recenzija.Tipas = reviewrequest.Tipas;
            recenzija.Zanras = reviewrequest.Zanras;

            var recenzijaUpdated = await _recenzijaRepository.Update(recenzija);

            return recenzijaUpdated;
        }
    }
}
