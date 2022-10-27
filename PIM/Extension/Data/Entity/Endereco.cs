using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension.Data.Entity
{
    [Table("Endereco")]
    public class Endereco
    {
        [Key, Column("id")]
        public int? Id { get; set; }
        [Column("logradouro")]
        public string Logradouro { get; set; }
        [Column("numero")]
        public int Numero { get; set; }
        [Column("cep")]
        public int CEP { get; set; }
        [Column("bairro")]
        public string Bairro { get; set; }
        [Column("cidade")]
        public string Cidade { get; set; }
        [Column("estado")]
        public string Estado { get; set; }
    }
}
