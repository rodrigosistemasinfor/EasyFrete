using EasyFreteApp.Domain.Seletores;
using System.Collections.Generic;

namespace EasyFreteApp.Domain.Service
{
    public interface IService<TDomain, TSeletor>
       where TDomain : DomainBase
       where TSeletor : SeletorBase
    {
        TDomain GetById(int id);
        TDomain Insert(TDomain obj);
        int Count(TSeletor seletor);
        IEnumerable<TDomain> GetList(TSeletor seletor);
        TDomain Update(TDomain solicitacaoAcompanhamentoDomain);
        void Delete(int id);
    }
}
