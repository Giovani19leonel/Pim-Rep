using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIM.WebForms.Constant
{
    public class ErrorResponseWebPages
    {
        public const string CamposDeletarInvalidos = "Para deletar um usuário é necessário informar o ID dele.";
        public const string CamposConsultarInvalidos = "Para consultar um usuário é necessário informar o CPF dele.";
        public const string CamposRegistrarInvalidos = "Para registrar um usuário é necessário informar todos os campos, menos o ID.";
        public const string CamposAtualizarInvalidos = "Para atualizar um usuário é necessário informar todos os campos.";
    }
}