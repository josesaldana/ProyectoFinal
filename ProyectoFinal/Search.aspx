<%@ Page Title="Búsqueda" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeFile="Search.aspx.vb" Inherits="Search" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="flex flex-col p-5">
        <%--<div class="flex flex-row items-center w-full justify-center">
            <asp:TextBox ID="TextBoxBusquedaTrabajo" runat="server" CssClass="input input-bordered w-1/4"></asp:TextBox>
            <asp:Button ID="ButtonBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary ml-3" OnClick="ButtonBuscar_Click" />
        </div>--%>

        <div class="w-full flex flex-row">
            <div class="w-1/4">
                <asp:Repeater ID="RepetidorDeFacetasDeBusqueda" runat="server">
                    <ItemTemplate>
                        <div class="p-5 flex flex-col">
                            <asp:PlaceHolder ID="FacetasDeBusquedaItemControlPlaceholder" runat="server"></asp:PlaceHolder>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div id="DivContenedorListaDeResultados" runat="server" visible="false" class="w-full p-5">
                <p>
                    Total de trabajos encontrados:
                    <asp:Label ID="LabelTotalDeResultados" runat="server" Text="Label" CssClass="py-5"></asp:Label>
                </p>

                <ul id="ListaDeResultados" runat="server" class="list-disc mt-5">
                    <asp:Repeater ID="RepetidorDeResultados" runat="server">
                        <ItemTemplate>
                            <li class="flex flex-col my-5">
                                <a href="JobDetails.aspx?Id=<%# Container.DataItem.Id %>" class="link link-info">
                                    <strong><%# Container.DataItem.Titulo %></strong>
                                </a>
                                <p><%# Container.DataItem.DescripcionCorta %></p>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>

