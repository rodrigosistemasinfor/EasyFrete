using EasyFreteApp.Application.Service.Abstract;
using EasyFreteApp.Domain;
using EasyFreteApp.Domain.Repository;
using EasyFreteApp.Domain.Seletores;
using EasyFreteApp.Domain.Service;

namespace EasyFreteApp.Application.Service
{
    public class RaioPrecoService : ServiceBase<IRaioPrecoRepository, RaioPrecoDomain, RaioPrecoSeletor>, IRaioPrecoService
    {
        public RaioPrecoService(IRaioPrecoRepository repository) : base(repository) { }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public override RaioPrecoDomain Update(RaioPrecoDomain domain)
        {
            throw new System.NotImplementedException();
        }

        public override RaioPrecoDomain Insert(RaioPrecoDomain domain)
        {
           //chamar validation
           return base.Insert(domain);
        }
    }
}
