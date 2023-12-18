Imports ProyectoFinal.Domain.Entities

Namespace Ports
    Public Interface IApplicationRepository
        Property Trabajos As IQueryable(Of Trabajo)
        Property Categorias As IQueryable(Of Categoria)
        Property Usuarios As IQueryable(Of Usuario)
        Property Aplicaciones As IQueryable(Of Aplicacione)

        Sub Add(Of T As Class)(entity As T)
        'Sub Add(usuario As Usuario)
        'Sub Add(aplicacion As Aplicacione)
        Sub SaveChanges()
        Function SaveChangesAsync() As Task
    End Interface
End Namespace
