Imports ProyectoFinal.Domain.Entities

Namespace Ports
    Public Interface IApplicationRepository
        Property Trabajos As IQueryable(Of Trabajo)
        Property Categorias As IQueryable(Of Categoria)
    End Interface
End Namespace
