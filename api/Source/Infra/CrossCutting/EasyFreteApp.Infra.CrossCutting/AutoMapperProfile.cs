using AutoMapper;
using EasyFreteApp.Domain;
using EasyFreteApp.Domain.Domain.Json;
using EasyFreteApp.Infra.Data.Entities;
using System;

namespace EasyFreteApp.Infra.CrossCutting
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UsuarioEntity, UsuarioDomain>();
            CreateMap<UsuarioDomain, UsuarioEntity>();
            
            CreateMap<EmpresaEntity, EmpresaDomain>();
            CreateMap<EmpresaDomain, EmpresaEntity>();

            CreateMap<CepEntity, CepDomain>();
            CreateMap<CepDomain, CepEntity>();

            CreateMap<CentroDistribuicaoEntity, CentroDistribuicaoDomain>();
            CreateMap<CentroDistribuicaoDomain, CentroDistribuicaoEntity>();

            CreateMap<RaioPrecoEntity, RaioPrecoDomain>();
            CreateMap<RaioPrecoDomain, RaioPrecoEntity>();


            //map json to domain
            CreateMap<CepJsonDomain, CepDomain>()
                    .ForMember(json => json.Cep, domain => domain.MapFrom(src => ConvertCep(src.Cep)))
                    .ForMember(json => json.Cidade, domain => domain.MapFrom(src => src.Localidade))
                    .ForMember(json => json.DataInclusao, domain => domain.MapFrom(src => DateTime.Now))
                    .ForMember(json => json.Ativo, domain => domain.MapFrom(src => true));
        }

        private decimal ConvertCep(string cep) 
            => string.IsNullOrEmpty(cep) ? 0 : decimal.Parse(cep.Replace("-", ""));
    }
}
