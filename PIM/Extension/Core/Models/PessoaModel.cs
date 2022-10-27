using Extension.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension.Core.Models
{
    public class PessoaModel
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public long CPF { get; set; }
        public Endereco Endereco { get; set; }
        public TelefoneModel Telefone { get; set; }
    }

    public class TelefoneModel
    {
        public int? Id { get; set; }
        public string Tipo { get; set; }
        public int Numero { get; set; }
        public int DDD { get; set; }
    }
}
