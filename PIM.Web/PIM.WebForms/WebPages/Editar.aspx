<%@ Page Title="" Language="C#" MasterPageFile="~/WebPages/Header.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="PIM.WebForms.WebPages.Editar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <h1 style="text-align: center; font-size: 35px; font-family: Arial, Helvetica, sans-serif; text-shadow: 0px 4px 4px rgba(0, 0, 0, 0.45); margin-top: 30px;">Editar usuários</h1>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
    <div class="linha">
        <div class="coluna pequeno-12 mediano-4 grande-2">
            <label for="cmpA">ID</label>
        </div>
        <div class="coluna pequeno-12 mediano-8 grande-4">
            <input runat="server" id="ID" type="number" name="id" maxlength=10/>
        </div>
        <div class="coluna pequeno-12 mediano-4 grande-2">        
            <label for="cmpB">Via</label>
        </div>
        <div class="coluna pequeno-12 mediano-8 grande-4">
            <input runat="server" id="Logradouro" type="text" name="logradouro" maxlength=60/>
        </div>
    </div>
        <div class="linha">
        <div class="coluna pequeno-12 mediano-4 grande-2">
            <label for="cmpC">CPF</label>
        </div>
        <div class="coluna pequeno-12 mediano-8 grande-4">
            <input runat="server" id="CPF" type="number" name="cpf" maxlength=11/>
        </div>
        <div class="coluna pequeno-12 mediano-4 grande-2">        
            <label for="cmpD">CEP</label>
        </div>
        <div class="coluna pequeno-12 mediano-8 grande-4">
            <input runat="server" id="CEP" type="number" name="cep" maxlength=8/>
        </div>
    </div> 
    <div class="linha">
        <div class="coluna pequeno-12 mediano-4 grande-2">
            <label for="cmpC">Nome</label>
        </div>
        <div class="coluna pequeno-12 mediano-8 grande-4">
            <input runat="server" id="Nome" type="text" name="Nome" maxlength=50/>
        </div>
        <div class="coluna pequeno-12 mediano-4 grande-2">        
            <label for="cmpD">Bairro</label>
        </div>
        <div class="coluna pequeno-12 mediano-8 grande-4">
            <input runat="server" id="Bairro" type="text" name="Bairro" maxlength=20/>
        </div>
    </div>
    
        <div class="linha">
        <div class="coluna pequeno-12 mediano-4 grande-2">
            <label for="cmpC">Telefone</label>
        </div>
        <div class="coluna pequeno-12 mediano-8 grande-4">
            <input runat="server" id="Telefone" type="number" name="Telefone" maxlength=20/>
        </div>
        <div class="coluna pequeno-12 mediano-4 grande-2">        
            <label for="cmpD">Número</label>
        </div>
        <div class="coluna pequeno-12 mediano-8 grande-4">
            <input runat="server" id="Numero" type="number" name="Numero" maxlength=10/>
        </div>
    </div> 
        <div class="linha">
        <div class="coluna pequeno-12 mediano-4 grande-2">
            <label for="cmpC">DDD</label>
        </div>
        <div class="coluna pequeno-12 mediano-8 grande-4">
            <input runat="server" id="DDD" type="number" name="DDD" maxlength=3/>
        </div>
        <div class="coluna pequeno-12 mediano-4 grande-2">        
            <label for="cmpD">Cidade</label>
        </div>
        <div class="coluna pequeno-12 mediano-8 grande-4">
            <input runat="server" id="Cidade" type="text" name="Cidade" maxlength=20/>
        </div>
    </div>  
        <div class="linha">
        <div class="coluna pequeno-12 mediano-4 grande-2">
            <label for="cmpC">Tipo</label>
        </div>
        <div class="coluna pequeno-12 mediano-8 grande-4">
            <select runat="server" action="#" class="dropInput" name="typeCellphone" id="TipoTelefone">
                <option runat="server" value="default">Selecione o tipo</option>
                <option runat="server" value="Fixo">Telefone fixo</option>
                <option runat="server" value="Movel">Telefone movel</option>
            </select>
        </div>
        <div class="coluna pequeno-12 mediano-4 grande-2">        
            <label for="cmpD">Estado</label>
        </div>
        <div class="coluna pequeno-12 mediano-8 grande-4">
            <input runat="server" id="Estado" type="text" name="estado" maxlength=20/>
        </div>
            <div>        
            <asp:Button type="button" ID="Botao1" onclick="DeletarUsuario" runat="server" Text="Deletar" class="botoescrud" style="margin:3% 20% 2% 8%; height: 35px; width: 150px;"/>
            <asp:Button type="button" ID="Botao2" onclick="RegistrarUsuario" runat="server" Text="Registrar" class="botoescrud" style="height: 35px; width: 150px;"/>
            <asp:Button type="button" ID="Botao3" onclick="AtualizarUsuario" runat="server" Text="Atualizar" class="botoescrud" style="margin: 0% 0% 0% 20%;width: 150px; height: 35px;"/>
        </div>
    </div> 
        
    </form>
</asp:Content>

