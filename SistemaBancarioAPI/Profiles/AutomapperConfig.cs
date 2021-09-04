using AutoMapper;
using SistemaBancarioAPI.Entities;
using SistemaBancarioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBancarioAPI.Profiles
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Conta, ContaDetailsViewModel>().ReverseMap();
            CreateMap<ContaViewModel, ContaDetailsViewModel>().ReverseMap();
            CreateMap<Conta, ContaViewModel>().ReverseMap();
            CreateMap<Conta, AddContaInputModel>().ReverseMap();
            CreateMap<Conta, UpdateContatInputModel>().ReverseMap();

            CreateMap<Titular, TitularViewModel>().ReverseMap();
            CreateMap<Titular, AddTitularInputModel>().ReverseMap();

            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Endereco, AddEnderecoInputModel>().ReverseMap();
        }
    }
}
