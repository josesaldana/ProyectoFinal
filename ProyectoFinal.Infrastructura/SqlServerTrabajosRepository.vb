Imports ProyectoFinal.Application
Imports ProyectoFinal.Application.Entities

Public Class SqlServerTrabajosRepository
    Implements ITrabajosRepository

    Private context As Ds8ProyectofinalContext

    Public Sub New(context As Ds8ProyectofinalContext)
        Me.context = context
    End Sub

    Public Function GetTrabajos() As List(Of Trabajo) Implements ITrabajosRepository.GetTrabajos
        Return context.Trabajos.ToList()
    End Function
End Class
