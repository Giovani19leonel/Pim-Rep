<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/WebPages/Header.Master" CodeBehind="Lista.aspx.cs" Inherits="PIM.WebForms.WebPages.Lista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <h1 style="text-align: center; font-size: 35px; font-family: Arial, Helvetica, sans-serif; text-shadow: 0px 4px 4px rgba(0, 0, 0, 0.45); margin-top: 30px;">Listar usuários</h1>
	<script src="https://code.jquery.com/jquery-3.6.0.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server">
        <div class="primeiraLinhaListar">
            <div class="labelListar">
                <label class="cpf listar">CPF</label>
            </div>
            <div>
            <input class="inputCpf listar" runat="server" id="GetCPF" type="number" name="id" maxlength=10/>
        </div>
             <div>
            <asp:Button type="button" ID="Button1" onclick="ConsultarUsuario" runat="server" Text="Consultar" class="botoescrud listar" style=""/>
        </div>
        </div>
		<div class="conteiners">
		<section class="container-fluid">
			<div style="margin-right: 18px;">
				<div class="col col-1 col-id">
					<div class="item id">
						<label class="camposGrid">ID</label>
					</div>
				</div>
				<div class="col col-1">
					<div class="item">
						<label class="camposGrid">CPF</label>
					</div>
				</div>
				<div class="col col-1 ">
					<div class="item">
						<label class="camposGrid">Nome</label>
					</div>
				</div>
				<div class="col col-1 ">
					<div class="item">
						<label class="camposGrid">Telefone</label>
					</div>
				</div>
				<div class="col col-1 ">
					<div class="item">
						<label class="camposGrid">DDD</label>
					</div>
				</div>
				<div class="col col-1 ">
					<div class="item">
						<label class="camposGrid">TipoTel</label>
					</div>
				</div>
				<div class="col col-1 ">
					<div class="item">
						<label class="camposGrid">Via</label>
					</div>
				</div>
				<div class="col col-1 ">
					<div class="item">
						<label class="camposGrid">CEP</label>
					</div>
				</div>
				<div class="col col-1 ">
					<div class="item">
						<label class="camposGrid">Bairro</label>
					</div>
				</div>
				<div class="col col-1 ">
					<div class="item">
						<label class="camposGrid">Numero</label>
					</div>
				</div>
				<div class="col col-1 ">
					<div class="item">
						<label class="camposGrid">Cidade</label>
					</div>
				</div>
				<div class="col col-1 ">
					<div class="item">
						<label class="camposGrid">Estado</label>
					</div>
				</div>
			</div>
			<div class="conteiners-registro">
			</div>
		</section>
		</div>
         </form>
    <style>	
		.conteiners{
			height: 450px;
			margin-top:40px;
			display:flex;
			background-color: #b1b1b1;
		}
		.inputCpf{
			text-align: initial;
		}
        .primeiraLinhaListar
        {
            display:flex;
            margin-left:25%
        }
        .listar {
            font-family: Arial, Helvetica, sans-serif;
            margin-left: 30px;
            margin-left:30px;
        }
        .labelListar
        {
            display:flex;
        }
		.conteiners-registro{
			display: flex;
			flex-direction:column;
			overflow-y: scroll;
			height: 100%;
			width:100%;
			margin-top:10px;
		}
		.container-fluid{
			display: flex;
			flex-direction: column;
		}
        @media only screen and (min-width: 450px)
        {
            .primeiraLinhaListar
            {
                margin-top:30px;
                flex-direction:column;
                align-items:center;
                margin-left:0;
            }
            .listar {
                margin-top:15px
            }
        }
        @media only screen and (min-width: 700px)
        {
            .primeiraLinhaListar
            {
                margin-left:25%;
                margin-top:30px;
                flex-direction:row;
                align-items:center;
            }
        }
        @media only screen and (min-width: 950px)
        {   .listar{
                font-size: 25px;
            }
            .primeiraLinhaListar
            {
                margin-left:30%;
                margin-top:30px;
                flex-direction:row;
                align-items:center;
            }
        }
		* {
		box-sizing: border-box;
		}

		:root {
		--screenSize: "extra small";
		--containerSize: auto; 
		--gutter: 3px;
		}
		/* // Small devices (landscape phones, 576px and up) */
		@media (min-width: 576px) { 
			:root {
				--screenSize: "small";
				--containerSize: 550px; 
			}
		}
		/* // Medium devices (tablets, 768px and up) */
		@media (min-width: 768px) { 
			:root {
				--screenSize: "medium";
				--containerSize: 750px; 
			}
		}

		/* // Large devices (desktops, 992px and up) */
		@media (min-width: 992px) { 
			:root {
				--screenSize: "large";
				--containerSize: 970px; 
			}
		}
		/* // Extra large devices (large desktops, 1200px and up) */
		@media (min-width: 1200px) { 
			:root {
				--screenSize: "extra large";
				--containerSize: 1170px; 
			}
		}
		@media (min-height: 570px)
		{
			.conteiners{
				height:380px;
			}
		}
		@media (min-height: 650px)
		{
			.conteiners{
				height:420px;
			}
		}

		
		.container-fluid {
			width: 100%;
			display: flex;
			flex-direction:column;
			/*margin-left: 20px*/
		}
		.container:after {
			content: "";
			display: table;
			clear: both;
		}
		.col {
			float: left;
			padding-left: var(--gutter);
			padding-right: var(--gutter);
		}
		.col-1 {
			width: 8.33333%;
		}
		/* Visual */
		* {
			text-align: center;
		}

		.item {
			background: black;
			border: 1px solid #bbb;
			padding: 5px;
			border-radius: 3px;
		}
		.item-input{
			background-color: #236800;
			display:flex;
			align-items:center;
			height:25px;
			border: 1px solid #bbb;
			padding: 5px;
		}
		span:before {
			content: var(--screenSize);
		}
		.camposGrid{
			font-family: Arial, Helvetica, sans-serif;
			font-size: 20px;
			color:white;
		}
		.via{
			font-size: 9px;
		}
		.col-col-1-col-registro{
			width: 8.33333%;
			float: left;
			padding-left: var(--gutter);
			padding-right: var(--gutter);
		}
		.camposGrid-camposInput{
			font-size: 10px;
			width: 100%;
			text-align: center;
			font-family: Arial, Helvetica, sans-serif;
			color:white;
		}
    </style>
</asp:Content>
