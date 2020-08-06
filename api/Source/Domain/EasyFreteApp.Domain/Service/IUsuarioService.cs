using EasyFreteApp.Domain.Seletores;

namespace EasyFreteApp.Domain.Service
{
    public interface IUsuarioService : IService<UsuarioDomain, UsuarioSeletor>
    {
        void Delete(UsuarioSeletor seletor);
    }
}
