using AutoMapper;
using BackEnd.Data.Contracts.Requests;
using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Extra
{
    public class Automapping : Profile
    {
        public Automapping()
        {
            CreateMap<KomentarasRequest, Komentaras>();
            CreateMap<AddUserRequest, Naudotojas>();
            CreateMap<UpdateUserRequest, Naudotojas>();
            CreateMap<ReviewRequest, Recenzija>();
            CreateMap<VertinimasRequest, Vertinimas>();
        }
    }
}
