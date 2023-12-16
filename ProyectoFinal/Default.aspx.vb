
Imports System.ComponentModel.Composition
Imports ProyectoFinal.Application.UseCases

Partial Public Class _Default
    Inherits Page

    <Import()> Public Property buscarTrabajoUseCase As BuscarTrabajoUseCase

    Protected Sub ButtonBuscar_Click(sender As Object, e As EventArgs) Handles ButtonBuscar.Click
        Dim trabajos = buscarTrabajoUseCase.Buscar(TextBoxBusquedaTrabajo.Text)
        Dim total = trabajos.Count()
    End Sub
End Class