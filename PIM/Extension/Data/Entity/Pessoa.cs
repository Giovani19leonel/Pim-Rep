using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension.Data.Entity
{
    [Table("Pessoa")]
    public class Pessoa
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Column("id_endereco")]
        public int IdEndereco { get; set; }
        [Column("nome")]
        public string Nome { get; set; }
        [Column("cpf")]
        public long CPF { get; set; }
    }
}
