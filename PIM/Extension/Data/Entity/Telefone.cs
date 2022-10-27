using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension.Data.Entity
{
    [Table("Telefone")]
    public class Telefone
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [ForeignKey("TipoTelefone"),Column("id_tipo")]
        public int id_tipo { get; set; }
        [Column("numero")]
        public int Numero { get; set; }
        [Column("ddd")]
        public int DDD { get; set; }
        
    }
}
