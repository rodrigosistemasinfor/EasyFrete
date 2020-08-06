using EasyFreteApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyFreteApp.Application.Service.Validators
{
    public static class UsuarioValidator
    {
       public static bool UsuarioIsValid(UsuarioDomain user)
       {
            if (user == null)
                 throw new Exception("Usuário inválido");
             else if(string.IsNullOrEmpty(user.Nome) || user.Nome.Length > 100)
                throw new Exception("Nome do usuário inválido");
            //mais validações..

            return true;
       }
    }
}
