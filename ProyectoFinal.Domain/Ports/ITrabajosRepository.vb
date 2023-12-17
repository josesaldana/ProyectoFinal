Imports ProyectoFinal.Domain.Entities

Namespace Ports
    Public Interface ITrabajosRepository
        Function ObtenerPorCriterioDeBusqueda(criterio As CriterioDeBusqueda) As (Integer, List(Of Trabajo))
    End Interface
End Namespace
