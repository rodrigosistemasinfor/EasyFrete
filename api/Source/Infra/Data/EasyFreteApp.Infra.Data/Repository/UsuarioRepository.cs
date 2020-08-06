using AutoMapper;
using EasyFreteApp.Domain;
using EasyFreteApp.Domain.Repository;
using EasyFreteApp.Domain.Seletores;
using EasyFreteApp.Infra.Data.Entities;
using EasyFreteApp.Infra.Data.Interface;
using EasyFreteApp.Infra.Data.Repository.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace EasyFreteApp.Infra.Data.Repository
{
    public class UsuarioRepository : RepositoryBase<UsuarioEntity, UsuarioDomain, UsuarioSeletor>, IUsuarioRepository
    {
        public UsuarioRepository(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public override IQueryable<UsuarioEntity> CreateParameters(UsuarioSeletor seletor, IQueryable<UsuarioEntity> query)
        {
            if (!string.IsNullOrEmpty(seletor.CPF))
                query = query.Where(x => x.CPF == seletor.CPF);

            if (!string.IsNullOrEmpty(seletor.RG))
                query = query.Where(x => x.RG == seletor.RG); ;
            
            if (!string.IsNullOrEmpty(seletor.Nome))
                query = query.Where(x => x.Nome.Contains(seletor.Nome));


            return query;
        }

        public IEnumerable<UsuarioDomain> GetListDelete(UsuarioSeletor usuario)
        {
            var query = CreateQuery();

            if (!string.IsNullOrEmpty(usuario.CPF))
                query = query.Where(x=> x.CPF == usuario.CPF);

            if (!string.IsNullOrEmpty(usuario.RG))
                query = query.Where(x => x.RG == usuario.RG);

            return _mapper.Map<IEnumerable<UsuarioDomain>>(query.ToList());
        }
    }
}
