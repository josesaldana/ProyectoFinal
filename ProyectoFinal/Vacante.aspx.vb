Imports ProyectoFinal.Application.UseCases
Imports System.ComponentModel.Composition

Partial Class JobDetails
    Inherits System.Web.UI.Page

    <Import()> Public Property buscarTrabajo As BuscarTrabajo

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim detalleDeTrabajo = buscarTrabajo.Invocar(CType(Request("Id"), Integer))

            LabelTituloDeTrabajo.InnerText = detalleDeTrabajo.Titulo
            ParrafoDescripcionDeTrabajo.Text = detalleDeTrabajo.DescripcionCompleta
            HipervinculoAplicar.NavigateUrl = "Aplicar.aspx/?vacante=" & CType(detalleDeTrabajo.Id, String)
        End If
    End Sub
End Class
