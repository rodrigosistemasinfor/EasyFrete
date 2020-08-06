using System;

namespace EasyFreteApp.Domain
{
    public class UsuarioDomain : DomainBase
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public DateTime DataNacimento { get; set; }
        public string NomeMae { get; set; }
        public string NomePai { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
