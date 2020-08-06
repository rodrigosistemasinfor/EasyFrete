using EasyFreteApp.Application.Service.Abstract;
using EasyFreteApp.Application.Service.Validators;
using EasyFreteApp.Domain;
using EasyFreteApp.Domain.Repository;
using EasyFreteApp.Domain.Seletores;
using EasyFreteApp.Domain.Service;
using System;
using System.Linq;

namespace EasyFreteApp.Application.Service
{
    public class UsuarioService : ServiceBase<IUsuarioRepository, UsuarioDomain, UsuarioSeletor>, IUsuarioService
    {
        public UsuarioService(IUsuarioRepository repository) : base(repository) { }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
        public void Delete(UsuarioSeletor seletor)
        {
            if (string.IsNullOrEmpty(seletor.CPF) && string.IsNullOrEmpty(seletor.RG))
                throw new Exception("Filtro inválido");

            var usuarios = _repository.GetList(seletor).ToList();
            _repository.DeleteMany(usuarios);
        }

        public override UsuarioDomain Update(UsuarioDomain domain)
        {
            throw new System.NotImplementedException();
        }

        public override UsuarioDomain Insert(UsuarioDomain domain)
        {
            domain.DataCadastro = DateTime.Now;
            UsuarioValidator.UsuarioIsValid(domain);

            if(_repository.GetList(new UsuarioSeletor { CPF = domain.CPF }).Any())
                throw new Exception("CPF já cadastrado");
            
            if (_repository.GetList(new UsuarioSeletor { RG = domain.RG }).Any())
                throw new Exception("RG já cadastrado");

            return base.Insert(domain);
        }
    }
}
