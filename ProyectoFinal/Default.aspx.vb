Imports System.ComponentModel.Composition
Imports ProyectoFinal.Application.UseCases
Imports ProyectoFinal.Domain

Partial Public Class _Default
    Inherits Page

    Protected Sub ButtonBuscar_Click(sender As Object, e As EventArgs) Handles ButtonBuscar.Click
        Response.Redirect("~/Search.aspx?term=" + TextBoxBusquedaTrabajo.Text)
    End Sub
End Class