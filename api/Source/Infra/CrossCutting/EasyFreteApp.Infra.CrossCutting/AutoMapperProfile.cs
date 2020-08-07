using AutoMapper;
using EasyFreteApp.Domain;
using EasyFreteApp.Infra.Data.Entities;

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
        }
    }
}
