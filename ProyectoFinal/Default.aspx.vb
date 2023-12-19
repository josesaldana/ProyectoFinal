Imports System.ComponentModel.Composition
Imports ProyectoFinal.Application.UseCases
Imports ProyectoFinal.Domain

Partial Public Class _Default
    Inherits Page

    <Import()> Public Property agruparTrabajosPorOficio As AgruparTrabajosPorOficio

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            RepeaterGruposTrabajosPorOficio.DataSource = agruparTrabajosPorOficio.Invocar()
            RepeaterGruposTrabajosPorOficio.DataBind()
        End If
    End Sub

    Protected Sub ButtonBuscar_Click(sender As Object, e As EventArgs) Handles ButtonBuscar.Click
        Response.Redirect("~/Search.aspx?term=" + TextBoxBusquedaTrabajo.Text)
    End Sub
End Class