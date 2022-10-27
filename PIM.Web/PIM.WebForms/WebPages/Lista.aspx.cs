using PIM.WebForms.Constant;
using PIM.WebForms.Core.Integration.PIM;
using PIM.WebForms.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PIM.WebForms.WebPages
{
    public partial class Lista : System.Web.UI.Page
    {
        private PIMServices _pim = new PIMServices();
        private CommonServices _common;
        private bool carregou;
        public Lista()
        {
            _common = new CommonServices(Page);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var resp = _pim.GetLstPessoa();
            if(resp.respError != null)
                _common.ResponseWebPages(resp.respError.Message);
            else
                _common.AddConteiners(resp.resp);
        }
        protected void ConsultarUsuario(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(GetCPF.Value))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(),
                "clientscript", $"\nalert('{ErrorResponseWebPages.CamposConsultarInvalidos}')\n", true);
                return;
            }

            /*Page.ClientScript.RegisterStartupScript(this.GetType(),
            "clientscript", $"console.log('teste')\n", true);*/

            var resp = _pim.GetPessoa(Convert.ToInt64(GetCPF.Value));

            if (resp.respError != null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(),
                "clientscript", $"\nalert('{resp.respError.Message}')\n", true);
            }
            else
            {
                
                Page.ClientScript.RegisterStartupScript(this.GetType(),
                    "clientscript", $"\n$('.conteiners-registro').empty()\nconsole.log('no método SearchCPFConteiners')\n$('.conteiners-registro').append($('{_common.StringConteiner(resp.resp)}'))\n", true);
                GetCPF.Value = "";
            }
        }
    }
}