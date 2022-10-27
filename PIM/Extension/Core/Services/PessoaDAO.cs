using AutoMapper;
using Extension.Core.Models;
using Extension.Data;
using Extension.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Extension.Core.Services
{
    public class PessoaDAO
    {
        private UserContext _userContext;

        public PessoaDAO(UserContext userContext)
        {
            _userContext = userContext;
        }

        protected async Task<PessoaModel> GetPessoa(long cpf)
        {
            var data = await (from a in _userContext.Pessoas
                              join b in _userContext.PessoaTelefone on a.Id equals b.IdPessoa
                              join c in _userContext.Telefones on b.IdTelefone equals c.Id
                              join d in _userContext.Enderecos on a.IdEndereco equals d.Id
                              join e in _userContext.TipoTelefones on c.id_tipo equals e.Id
                              where a.CPF.Equals(cpf)
                              select new
                              {
                                  pessoa = a,
                                  telefone = c,
                                  endereco = d,
                                  tipoTelefone = e.Tipo
                              }).FirstOrDefaultAsync();


            if (data == null)
                return null;
            if (data.endereco == null)
                return null;
            if (data.telefone == null)
                return null;
            if (data.pessoa == null)
                return null;
            if (data.tipoTelefone == null)
                return null;

            return new PessoaModel()
            {
                Id = data.pessoa.Id,
                CPF = data.pessoa.CPF,
                Nome = data.pessoa.Nome,
                Endereco = data.endereco,
                Telefone = new TelefoneModel
                {
                    Id = data.telefone.Id,
                    DDD = data.telefone.DDD,
                    Numero = data.telefone.Numero,
                    Tipo = data.tipoTelefone
                }
            };
        }
        protected async Task<string> UpdatePessoa(PessoaModel pessoa)
        {
            if (pessoa.Id == null)
                return "ID não pode ser vazio";

            var data = await (from a in _userContext.Pessoas
                              join b in _userContext.PessoaTelefone on a.Id equals b.IdPessoa
                              join c in _userContext.Telefones on b.IdTelefone equals c.Id
                              join d in _userContext.Enderecos on a.IdEndereco equals d.Id
                              join e in _userContext.TipoTelefones on c.id_tipo equals e.Id
                              where a.Id.Equals(pessoa.Id)
                              select new
                              {
                                  pessoa = a,
                                  telefone = c,
                                  endereco = d
                              }).FirstOrDefaultAsync();

            var tipoTelefone = await _userContext.TipoTelefones.Where(x => x.Tipo.Equals(pessoa.Telefone.Tipo)).FirstOrDefaultAsync();

            if (data == null)
                return string.Empty;
            if (data.endereco == null)
                return string.Empty;
            if (data.telefone == null)
                return string.Empty;
            if (data.pessoa == null)
                return string.Empty;
            if (tipoTelefone == null)
                return string.Empty;

            data.pessoa.CPF = pessoa.CPF;
            data.pessoa.Nome = pessoa.Nome;

            data.endereco.CEP = pessoa.Endereco.CEP;
            data.endereco.Cidade = pessoa.Endereco.Cidade;
            data.endereco.Logradouro = pessoa.Endereco.Logradouro;
            data.endereco.Numero = pessoa.Endereco.Numero;
            data.endereco.Bairro = pessoa.Endereco.Bairro;
            data.endereco.Estado = pessoa.Endereco.Estado;

            data.telefone.Numero = pessoa.Telefone.Numero;
            data.telefone.id_tipo = tipoTelefone.Id;
            data.telefone.DDD = pessoa.Telefone.DDD;

            await _userContext.SaveChangesAsync();

            return null;
        }
        protected async Task<(bool valid, string errorResp)> InsertPessoa(PessoaModel pessoaModel)
        {
            if (pessoaModel == null)
                return (false, "Os dados não podem ser vazio.");

            var user = await _userContext.Pessoas.Where(x => x.CPF.Equals(pessoaModel.CPF)).FirstOrDefaultAsync();

            if (user != null)
                return (false, "Esse usuário já existe.");

            TipoTelefone tipoTelefone = await _userContext.TipoTelefones.Where(x => x.Tipo.Equals(pessoaModel.Telefone.Tipo)).FirstOrDefaultAsync();
            if (tipoTelefone == null)
            {
                tipoTelefone = new() 
                { 
                    Tipo = pessoaModel.Telefone.Tipo 
                };
                await _userContext.TipoTelefones.AddAsync(tipoTelefone);
                await _userContext.SaveChangesAsync();
            }

            Telefone telefone = new()
            {
                id_tipo = tipoTelefone.Id,
                DDD = pessoaModel.Telefone.DDD,
                Numero = pessoaModel.Telefone.Numero,
            };

            Endereco endereco = new()
            {
                Bairro = pessoaModel.Endereco.Bairro,
                CEP = pessoaModel.Endereco.CEP,
                Cidade = pessoaModel.Endereco.Cidade,
                Estado = pessoaModel.Endereco.Estado,
                Logradouro = pessoaModel.Endereco.Logradouro,
                Numero = pessoaModel.Endereco.Numero
            };

            await _userContext.Telefones.AddAsync(telefone);
            await _userContext.Enderecos.AddAsync(endereco);
            await _userContext.SaveChangesAsync();

            Pessoa pessoa = new()
            {
                Nome = pessoaModel.Nome,
                CPF = pessoaModel.CPF,
                IdEndereco = (int)endereco.Id
            };
            await _userContext.Pessoas.AddAsync(pessoa);
            await _userContext.SaveChangesAsync();

            PessoaTelefone pessoaTelefone = new()
            {
                IdPessoa = pessoa.Id,
                IdTelefone = telefone.Id
            };
            await _userContext.PessoaTelefone.AddAsync(pessoaTelefone);
            await _userContext.SaveChangesAsync();

            return (true, null);
        }
        protected async Task<(bool valid, string errorResp)> DeletePessoa(int id)
        {
            if (id == null)
                return (false, "O id não pode ser vazio");

            var data = await (from a in _userContext.Pessoas
                              join b in _userContext.PessoaTelefone on a.Id equals b.IdPessoa
                              join c in _userContext.Telefones on b.IdTelefone equals c.Id
                              join d in _userContext.Enderecos on a.IdEndereco equals d.Id
                              join e in _userContext.TipoTelefones on c.id_tipo equals e.Id
                              where a.Id.Equals(id)
                              select new
                              {
                                  pessoa = a,
                                  pessoaTelefone = b,
                                  telefone = c,
                                  endereco = d
                              }).FirstOrDefaultAsync();

            if (data == null)
                return (false, string.Empty);

            _userContext.PessoaTelefone.Remove(data.pessoaTelefone);
            await _userContext.SaveChangesAsync();
            _userContext.Telefones.Remove(data.telefone);            
            _userContext.Pessoas.Remove(data.pessoa);
            await _userContext.SaveChangesAsync();
            _userContext.Enderecos.Remove(data.endereco);
            await _userContext.SaveChangesAsync();

            return (true, null);
        }

        protected async Task<List<PessoaModel>> GetListaPessoas()
        {
            var data = await (from a in _userContext.Pessoas
                              join b in _userContext.PessoaTelefone on a.Id equals b.IdPessoa
                              join c in _userContext.Telefones on b.IdTelefone equals c.Id
                              join d in _userContext.Enderecos on a.IdEndereco equals d.Id
                              join e in _userContext.TipoTelefones on c.id_tipo equals e.Id
                              select new
                              {
                                  pessoa = a,
                                  telefone = c,
                                  endereco = d,
                                  tipo = e
                              }).ToListAsync();

            if (data == null)
                return null;

            List<PessoaModel> lstPessoas = data.Select(x =>
            new PessoaModel()
            {
                Id = x.pessoa.Id,
                CPF = x.pessoa.CPF,
                Nome = x.pessoa.Nome,
                Endereco = x.endereco,
                Telefone = new TelefoneModel()
                {
                    DDD = x.telefone.DDD,
                    Numero = x.telefone.Numero,
                    Tipo = x.tipo.Tipo
                }
            }).ToList();

           return lstPessoas;
        }
    }
}
