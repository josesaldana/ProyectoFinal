<%@ Page Title="Home Page" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="hero min-h-screen bg-base-200">
      <div class="hero-content text-center">
        <div class="max-w-xl">
          <h1 class="text-5xl font-bold">Encuentro Trabajo!</h1>
          <p class="py-6">Encuentre el oficio que busca o sue&ntilde;o en segundos y aplique! Ingrese cualquier t&eacute;rmino relacionado a su b&uacute;squeda y seleccione Buscar.</p>
            <div class="flex flex-row items-center justify-center">
                <asp:TextBox ID="TextBoxBusquedaTrabajo" runat="server" CssClass="input input-bordered w-1/2"></asp:TextBox>
                <asp:Button ID="ButtonBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary ml-3" OnClick="ButtonBuscar_Click" />
            </div>
        </div>
      </div>
    </div>
</asp:Content>
