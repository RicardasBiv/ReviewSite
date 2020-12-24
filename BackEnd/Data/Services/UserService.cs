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
    public class UserService : BaseService<Naudotojas, IUserRepository>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRecenzijaRepository _recenzijaRepository;
        private readonly IMapper _mapper;

        public UserService(IRecenzijaRepository recenzijaRepository,
                                  IUserRepository userRepository,
                                  IMapper mapper) : base(userRepository)
        {
            _userRepository = userRepository;
            _recenzijaRepository = recenzijaRepository;
            _mapper = mapper;
        }


        public async Task<Naudotojas> AddUser(AddUserRequest userRequest)
        {
            var user = _mapper.Map<Naudotojas>(userRequest);
            var userAdded = await _userRepository.Add(user);

            return userAdded;
        }

        public async Task<Naudotojas> DeleteUser(int id)
        {
            var userDeleted = await _userRepository.Delete(id);

            return userDeleted;
        }

        public async Task<UserResponse> GetUser(int id)
        {
            return await _userRepository.GetUser(id);
        }

        public async Task<IList<UserResponse>> GetUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async Task<Naudotojas> UpdateUser(int id, UpdateUserRequest userRequest)
        {
            var user = await _userRepository.Get(id);

            user.Email = userRequest.Email;

            var userUpdated = await _userRepository.Update(user);

            return userUpdated;
        }
    }
}
