using AutoMapper;
using EasyFreteApp.Domain;
using EasyFreteApp.Domain.Repository;
using EasyFreteApp.Domain.Seletores;
using EasyFreteApp.Infra.Data.Entities;
using EasyFreteApp.Infra.Data.Interface;
using EasyFreteApp.Infra.Data.Repository.Abstract;
using System.Linq;

namespace EasyFreteApp.Infra.Data.Repository
{
    public class RaioPrecoRepository : RepositoryBase<RaioPrecoEntity, RaioPrecoDomain, RaioPrecoSeletor>, IRaioPrecoRepository
    {
        public RaioPrecoRepository(IUnitOfWork uow, IMapper mapper) : base(uow, mapper) { }

        public override IQueryable<RaioPrecoEntity> CreateParameters(RaioPrecoSeletor seletor, IQueryable<RaioPrecoEntity> query)
        {
            if (seletor.IdCentroDistribuicao.HasValue)
                query = query.Where(x => x.IdCentroDistribuicao == seletor.IdCentroDistribuicao.Value);

            return query;
        }
    }
}
