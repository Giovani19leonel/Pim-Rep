﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension.Data.Entity
{
    [Table("TipoTelefone")]
    public class TipoTelefone
    {
        [Key, Column("id")]
        public int Id { get; set; }
        [Column("tipo")]
        public string Tipo { get; set; }
    }
}
