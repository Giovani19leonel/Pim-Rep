using PIM.WebForms.Core.Integration.PIM.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace PIM.WebForms.Core.Services
{
    public class CommonServices
    {
        private Page _page;
        public CommonServices(Page page)
        {
            _page = page;
        }
        public void DebugConsoleJS(string value)
        {
            _page.ClientScript.RegisterStartupScript(this.GetType(),
            "clientscript", $"console.log('{value}')\n", true);
        }

        public void DebugConsoleJS(int value)
        {
            _page.ClientScript.RegisterStartupScript(this.GetType(),
            "clientscript", $"console.log('{value}')\n", true);
        }
        public void ResponseWebPages(string value)
        {
            _page.ClientScript.RegisterStartupScript(this.GetType(),
                "clientscript", $"alert('{value}')\n", true);
        }

        public void AddConteiners(List<DefaultPIM> lstDefaultPim)
        {
            lstDefaultPim = lstDefaultPim.OrderByDescending(x => x.Id).ToList();
            string totalConteiners = "";
            
            foreach (var pim in lstDefaultPim)
            {
                string _conteiners = "<div>" +
                                          "<div class=col-col-1-col-registro>" +
                                                "<div class=item-input>" +
                                                  $"<label class=camposGrid-camposInput>{pim.Id}</label>" +
                                                "</div>" +
                                           "</div>" +
                                            "<div class=col-col-1-col-registro>" +
                                              "<div class=item-input>" +
                                                $"<label class=camposGrid-camposInput>{pim.CPF}</label>" +
                                              "</div>" +
                                           " </div>" +
                                            "<div class=col-col-1-col-registro>" +
                                              "<div class=item-input>" +
                                               $"<label class=camposGrid-camposInput>{pim.Nome}</label>" +
                                             " </div>" +
                                            "</div>" +
                                            "<div class=col-col-1-col-registro>" +
                                              "<div class=item-input>" +
                                               $"<label class=camposGrid-camposInput>{pim.Telefone.Numero}</label>" +
                                             " </div>" +
                                           " </div>" +
                                            "<div class=col-col-1-col-registro>" +
                                             " <div class=item-input>" +
                                                $"<label class=camposGrid-camposInput>{pim.Telefone.DDD}</label>" +
                                             " </div>" +
                                           " </div>" +
                                            "<div class=col-col-1-col-registro>" +
                                            "   <div class=item-input>" +
                                                $"<label class=camposGrid-camposInput>{pim.Telefone.Tipo}</label>" +
                                             " </div>" +
                                            "</div>" +
                                            "<div class=col-col-1-col-registro>" +
                                             " <div class=item-input>" +
                                                $"<label class=camposGrid-camposInput via>{pim.Endereco.Logradouro}</label>" +
                                             " </div>" +
                                            "</div>" +
                                            "<div class=col-col-1-col-registro>" +
                                              "<div class=item-input>" +
                                               $" <label class=camposGrid-camposInput>{pim.Endereco.CEP}</label>" +
                                             " </div>" +
                                            "</div>" +
                                            "<div class=col-col-1-col-registro>" +
                                             " <div class=item-input>" +
                                               $" <label class=camposGrid-camposInput>{pim.Endereco.Bairro}</label>" +
                                             " </div>" +
                                           " </div>" +
                                            "<div class=col-col-1-col-registro>" +
                                             " <div class=item-input>" +
                                              $"  <label class=camposGrid-camposInput>{pim.Endereco.Numero}</label>" +
                                            "  </div>" +
                                          "  </div>" +
                                            "<div class=col-col-1-col-registro>" +
                                             " <div class=item-input>" +
                                              $"  <label class=camposGrid-camposInput>{pim.Endereco.Cidade}</label>" +
                                             " </div>" +
                                           " </div>" +
                                            "<div class=col-col-1-col-registro>" +
                                             " <div class=item-input>" +
                                                $"<label class=camposGrid-camposInput>{pim.Endereco.Estado}</label>" +
                                              "</div>" +
                                            "</div>" +
                                        "</div>";

                totalConteiners = totalConteiners + _conteiners;
            }

            _page.ClientScript.RegisterStartupScript(this.GetType(),
                    "clientscript", $"$('.conteiners-registro').append($('{totalConteiners}'))", true);
        }

        public string StringConteiner(DefaultPIM pim)
        {
            return "<div>" +
                        "<div class=col-col-1-col-registro>" +
                            "<div class=item-input>" +
                                $"<label class=camposGrid-camposInput>{pim.Id}</label>" +
                            "</div>" +
                        "</div>" +
                        "<div class=col-col-1-col-registro>" +
                            "<div class=item-input>" +
                            $"<label class=camposGrid-camposInput>{pim.CPF}</label>" +
                            "</div>" +
                        " </div>" +
                        "<div class=col-col-1-col-registro>" +
                            "<div class=item-input>" +
                            $"<label class=camposGrid-camposInput>{pim.Nome}</label>" +
                        " </div>" +
                        "</div>" +
                        "<div class=col-col-1-col-registro>" +
                            "<div class=item-input>" +
                            $"<label class=camposGrid-camposInput>{pim.Telefone.Numero}</label>" +
                        " </div>" +
                        " </div>" +
                        "<div class=col-col-1-col-registro>" +
                        " <div class=item-input>" +
                            $"<label class=camposGrid-camposInput>{pim.Telefone.DDD}</label>" +
                        " </div>" +
                        " </div>" +
                        "<div class=col-col-1-col-registro>" +
                        "   <div class=item-input>" +
                            $"<label class=camposGrid-camposInput>{pim.Telefone.Tipo}</label>" +
                        " </div>" +
                        "</div>" +
                        "<div class=col-col-1-col-registro>" +
                        " <div class=item-input>" +
                            $"<label class=camposGrid-camposInput via>{pim.Endereco.Logradouro}</label>" +
                        " </div>" +
                        "</div>" +
                        "<div class=col-col-1-col-registro>" +
                            "<div class=item-input>" +
                            $" <label class=camposGrid-camposInput>{pim.Endereco.CEP}</label>" +
                        " </div>" +
                        "</div>" +
                        "<div class=col-col-1-col-registro>" +
                        " <div class=item-input>" +
                            $" <label class=camposGrid-camposInput>{pim.Endereco.Bairro}</label>" +
                        " </div>" +
                        " </div>" +
                        "<div class=col-col-1-col-registro>" +
                        " <div class=item-input>" +
                            $"  <label class=camposGrid-camposInput>{pim.Endereco.Numero}</label>" +
                        "  </div>" +
                        "  </div>" +
                        "<div class=col-col-1-col-registro>" +
                        " <div class=item-input>" +
                            $"  <label class=camposGrid-camposInput>{pim.Endereco.Cidade}</label>" +
                        " </div>" +
                        " </div>" +
                        "<div class=col-col-1-col-registro>" +
                        " <div class=item-input>" +
                            $"<label class=camposGrid-camposInput>{pim.Endereco.Estado}</label>" +
                            "</div>" +
                        "</div>" +
                    "</div>";        
        }
    }
}