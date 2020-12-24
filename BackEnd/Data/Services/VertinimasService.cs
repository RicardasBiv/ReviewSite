using AutoMapper;
using BackEnd.Data.Contracts.Requests;
using BackEnd.Data.Contracts.Responses;
using BackEnd.Data.Repositories.IRepositories;
using BackEnd.Data.Services.IServices;
using BackEnd.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace BackEnd.Data.Services
{
    public class VertinimasService : BaseService<Vertinimas, IVertinimasRepository>, IVertinimasService
    {
        private readonly IKomentarasRepository _komentarasRepository;
        private readonly IVertinimasRepository _vertinimasRepository;
        private readonly IMapper _mapper;

        public VertinimasService(IKomentarasRepository komentarasRepository,
                                  IVertinimasRepository vertinimasRepository,
                                  IMapper mapper) : base(vertinimasRepository)
        {
            _komentarasRepository = komentarasRepository;
            _vertinimasRepository = vertinimasRepository;
            _mapper = mapper;
        }

        public async Task<Vertinimas> AddVertinimas(VertinimasRequest vertinimasRequest)
        {
            var vertinimas = _mapper.Map<Vertinimas>(vertinimasRequest);
            var vertinimasAdded = await _vertinimasRepository.Add(vertinimas);

            return vertinimasAdded;
        }

        public async Task<Vertinimas> DeleteVertinimas(int id)
        {
            var vertinimas = await _vertinimasRepository.Get(id);
            var vertinimasDeleted = await _vertinimasRepository.Delete(id);

            return vertinimasDeleted;
        }

        public async Task<IVertinimasResponse> GetVertinimas(int id)
        {
            return await _vertinimasRepository.GetVertinimas(id);
        }

        public async Task<IList<IVertinimasResponse>> GetAllVertinimas()
        {
            return await _vertinimasRepository.GetAllVertinimas();
        }
        public async Task<Vertinimas> UpdateVertinimas(int id, VertinimasRequest vertinimasRequest)
        {
            var vertinimas = await _vertinimasRepository.Get(id);
            vertinimas.Vertinimas1 = vertinimasRequest.Vertinimas1;

            var vertinimasUpdated = await _vertinimasRepository.Update(vertinimas);

            return vertinimasUpdated;
        }
    }
}
