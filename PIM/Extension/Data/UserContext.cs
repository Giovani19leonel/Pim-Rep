using Extension.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension.Data
{
    public class UserContext : DbContext
    {
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<TipoTelefone> TipoTelefones { get; set; }
        public DbSet<PessoaTelefone> PessoaTelefone { get; set; }
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }
    }
}
