using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIM.WebForms.Core.Integration.PIM.Contracts
{
    public class DefaultPIM
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public long CPF { get; set; }
        public EnderecoModel Endereco { get; set; }
        public TelefoneModel Telefone { get; set; }
    }

    public class EnderecoModel
    {
        public int? Id { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public int CEP { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }

    public class TelefoneModel
    {
        public int? Id { get; set; }
        public string Tipo { get; set; }
        public int Numero { get; set; }
        public int DDD { get; set; }
    }
}