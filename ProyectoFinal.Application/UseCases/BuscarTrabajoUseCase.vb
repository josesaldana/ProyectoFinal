
Imports ProyectoFinal.Application.Entities

Namespace UseCases
    Public Class BuscarTrabajoUseCase
        Private trabajosRepository As ITrabajosRepository

        Public Sub New(trabajosRepository As ITrabajosRepository)
            Me.trabajosRepository = trabajosRepository
        End Sub
        Public Function Buscar(texto As String) As List(Of Trabajo)
            Return trabajosRepository.GetTrabajos()
        End Function
    End Class
End Namespace
