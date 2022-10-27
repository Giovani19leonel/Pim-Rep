using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension.Data.Entity
{
    [Table("PessoaTelefone")]
    public class PessoaTelefone
    {
        [Key, Column("id")]
        public int? Id { get; set; }
        [ForeignKey("Pessoa"),Column("id_pessoa")]
        public int IdPessoa { get; set; }
        [ForeignKey("Telefone"), Column("id_telefone")]
        public int IdTelefone { get; set; }
    }
}
