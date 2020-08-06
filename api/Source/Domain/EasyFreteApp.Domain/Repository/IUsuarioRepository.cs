using EasyFreteApp.Domain.Repository.Abstract;
using EasyFreteApp.Domain.Seletores;
using System.Collections.Generic;

namespace EasyFreteApp.Domain.Repository
{
    public interface IUsuarioRepository : IRepositorySeletorBase<UsuarioDomain, UsuarioSeletor>
    {
        IEnumerable<UsuarioDomain> GetListDelete(UsuarioSeletor usuario);
    }
}
