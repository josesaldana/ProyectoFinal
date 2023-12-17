Imports ProyectoFinal.Domain.Entities
Imports ProyectoFinal.Domain.Ports
Imports ProyectoFinal.Domain

Namespace UseCases
    Public Class BuscarTrabajo
        Private trabajosRepository As ITrabajosRepository

        Public Sub New(trabajosRepository As ITrabajosRepository)
            Me.trabajosRepository = trabajosRepository
        End Sub

        Public Function Buscar(busqueda As CriterioDeBusqueda) As ResultadoDeBusqueda(Of Trabajo)
            Dim resultados = trabajosRepository.ObtenerPorCriterioDeBusqueda(busqueda)

            Return New ResultadoDeBusqueda(Of Trabajo) With {
                .Resultados = resultados.Item2,
                .Total = resultados.Item1,
                .CriterioDeBusqueda = busqueda
            }
        End Function
    End Class
End Namespace
