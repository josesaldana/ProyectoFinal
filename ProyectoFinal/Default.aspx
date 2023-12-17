<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="hero min-h-screen bg-base-200">
      <div class="hero-content text-center w-2/3 flex flex-col">
        <h1 class="text-5xl font-bold col-span-3">¡Encuentro Trabajo!</h1>
        <p class="py-2">Encuentre el oficio que busca o sue&ntilde;a en minutos y aplique! Muchas vacantes esperando por t&iacute;!</p>
        <div class="flex flex-row items-center">
            <div class="w-full px-10">
                <p class="py-6">Ingresa cualquier t&eacute;rmino relacionado a tu b&uacute;squeda y seleccione Buscar.</p>
                <div class="flex flex-row items-center justify-center">
                    <asp:TextBox ID="TextBoxBusquedaTrabajo" runat="server" CssClass="input input-bordered w-1/2"></asp:TextBox>
                    <asp:Button ID="ButtonBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary ml-3" OnClick="ButtonBuscar_Click" />
                </div>
            </div>
            <div class="divider lg:divider-horizontal">O</div> 
            <div class="w-full px-10">
              <p class="py-6">Explora las vacantes disponibles y aplica a la que sientas que eres un buen candidato!</p>
              <a  href="Search.aspx" class="btn btn-primary ml-3">Ver Trababajos</a>
            </div>
        </div>
      </div>
    </div>
</asp:Content>
