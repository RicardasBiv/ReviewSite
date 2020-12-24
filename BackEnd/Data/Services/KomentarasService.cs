using AutoMapper;
using BackEnd.Data.Contracts.Requests;
using BackEnd.Data.Contracts.Responses;
using BackEnd.Data.Repositories;
using BackEnd.Data.Repositories.IRepositories;
using BackEnd.Data.Services.IServices;
using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Data.Services
{
    public class KomentarasService : BaseService<Komentaras, IKomentarasRepository>, IKomentarasService
    {
        private readonly IKomentarasRepository _komentarasRepository;
        private readonly IVertinimasRepository _vertinimasRepository;
        private readonly IMapper _mapper;

        public KomentarasService(IKomentarasRepository komentarasRepository,
                                  IVertinimasRepository vertinimasRepository,
                                  IMapper mapper) : base(komentarasRepository)
        {
            _komentarasRepository = komentarasRepository;
            _vertinimasRepository = vertinimasRepository;
            _mapper = mapper;
        }

        public async Task<Komentaras> AddKomentaras(KomentarasRequest komentarasRequest)
        {
            var komentaras = _mapper.Map<Komentaras>(komentarasRequest);
            var komentarasAdded = await _komentarasRepository.Add(komentaras);

            return komentarasAdded;
        }

        public async Task<Komentaras> DeleteKomentaras(int id)
        {
            var komentarasdeleted = await _komentarasRepository.Delete(id);

            return komentarasdeleted;
        }

        public async Task<KomentarasResponse> GetKomentaras(int id)
        {
            return await _komentarasRepository.GetKomentaras(id);
        }

        public async Task<IList<KomentarasResponse>> GetAllKomentarai(int recenzijuid)
        {
            return await _komentarasRepository.GetAllKomentarai(recenzijuid);
        }
        public async Task<Komentaras> UpdateKomentaras(int id, KomentarasRequest komentarasRequest)
        {
            var komentaras = await _komentarasRepository.Get(id);
            komentaras.Komentaras1 = komentarasRequest.Komentaras1;
            komentaras.VertinimasId = komentarasRequest.VertinimasId;

            var komentarasUdated = await _komentarasRepository.Update(komentaras);

            return komentarasUdated;
        }
    }
}
