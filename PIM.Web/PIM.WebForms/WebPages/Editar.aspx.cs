using PIM.WebForms.Constant;
using PIM.WebForms.Core.Integration.PIM;
using PIM.WebForms.Core.Integration.PIM.Contracts;
using PIM.WebForms.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PIM.WebForms.WebPages
{
    public partial class Editar : System.Web.UI.Page
    {

        private PIMServices _pim = new PIMServices();
        private CommonServices _common;
        public Editar()
        {
            _common = new CommonServices(Page);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void DeletarUsuario(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ID.Value))
            {
                _common.ResponseWebPages(ErrorResponseWebPages.CamposDeletarInvalidos);
                return;
            }

            var resp = _pim.DeletarPessoa(Convert.ToInt32(ID.Value));

            if (!resp.resp && resp.respError != null)
                _common.ResponseWebPages(resp.respError.Message);
            else
            {
                _common.ResponseWebPages("Usuário deletado com sucesso!");
                ClearProps();
            }
        }

        protected void RegistrarUsuario(object sender, EventArgs e)
        {
            
            if (!IsValid())
            {
                _common.ResponseWebPages(ErrorResponseWebPages.CamposRegistrarInvalidos);
                return;
            }
                
            
            var resp = _pim.IncluirPostPessoa(new DefaultPIM
            {
                Nome = Nome.Value,
                CPF = Convert.ToInt64(CPF.Value),
                Endereco  = new EnderecoModel()
                {
                    Bairro = Bairro.Value,
                    Cidade = Cidade.Value,
                    Estado = Estado.Value,
                    Logradouro = Logradouro.Value,
                    CEP = Convert.ToInt32(CEP.Value),
                    Numero = Convert.ToInt32(Numero.Value)
                },
                Telefone = new TelefoneModel()
                {
                    Numero = Convert.ToInt32(Telefone.Value),
                    DDD = Convert.ToInt32(DDD.Value),
                    Tipo = TipoTelefone.Value
                }

            });

            if(!resp.resp && resp.respError != null)
                _common.ResponseWebPages(resp.respError.Message);
            else
            {
                _common.ResponseWebPages("Usuário cadastrado com sucesso!");
                ClearProps();
            }
        }

        protected void AtualizarUsuario(object sender, EventArgs e)
        {
            if(!IsValid(true))
            {
                _common.ResponseWebPages(ErrorResponseWebPages.CamposAtualizarInvalidos);
                return;
            }
                

            var resp = _pim.AtualizarPostPessoa(new DefaultPIM
            {
                Id = Convert.ToInt32(ID.Value),
                Nome = Nome.Value,
                CPF = Convert.ToInt64(CPF.Value),
                Endereco = new EnderecoModel()
                {
                    Bairro = Bairro.Value,
                    Cidade = Cidade.Value,
                    Estado = Estado.Value,
                    Logradouro = Logradouro.Value,
                    CEP = Convert.ToInt32(CEP.Value),
                    Numero = Convert.ToInt32(Numero.Value)
                },
                Telefone = new TelefoneModel()
                {
                    Numero = Convert.ToInt32(Telefone.Value),
                    DDD = Convert.ToInt32(DDD.Value),
                    Tipo = TipoTelefone.Value
                }
            });

            if (!resp.resp && resp.respError != null)
                _common.ResponseWebPages(resp.respError.Message);
            else
            {
                _common.ResponseWebPages("Usuário atualizado com sucesso!");
                ClearProps();
            }
        }

        private bool IsValid(bool atualizar = false)
        {
            if ((atualizar ? string.IsNullOrEmpty(ID.Value) : false) || string.IsNullOrEmpty(Logradouro.Value) || string.IsNullOrEmpty(CEP.Value)
                || string.IsNullOrEmpty(Nome.Value) || string.IsNullOrEmpty(Bairro.Value)
                || string.IsNullOrEmpty(Telefone.Value) || string.IsNullOrEmpty(Numero.Value)
                || string.IsNullOrEmpty(DDD.Value) || string.IsNullOrEmpty(Cidade.Value)
                || TipoTelefone.Value == "default" || string.IsNullOrEmpty(Estado.Value))
                return false;
            return true;
        }
        private void ClearProps()
        {
            ID.Value = "";
            Logradouro.Value = "";
            CPF.Value = "";
            CEP.Value = "";
            Nome.Value = "";
            Bairro.Value = "";
            Telefone.Value = "";
            Numero.Value = "";
            DDD.Value = "";
            Cidade.Value = "";
            Estado.Value = "";
            TipoTelefone.Value = "default";
        }
    }
}