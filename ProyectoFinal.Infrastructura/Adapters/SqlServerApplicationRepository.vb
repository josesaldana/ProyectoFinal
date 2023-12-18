Imports ProyectoFinal.Domain.Entities
Imports ProyectoFinal.Domain.Ports

Namespace Adapters
    Public Class SqlServerApplicationRepository
        Implements IApplicationRepository

        Private context As Ds8ProyectofinalContext

        Public Sub New(context As Ds8ProyectofinalContext)
            Me.context = context
        End Sub

        Public Property Trabajos As IQueryable(Of Trabajo) Implements IApplicationRepository.Trabajos
            Get
                Return context.Trabajos.AsQueryable()
            End Get
            Set(value As IQueryable(Of Trabajo))
                Throw New InvalidOperationException
            End Set
        End Property

        Public Property Categorias As IQueryable(Of Categoria) Implements IApplicationRepository.Categorias
            Get
                Return context.Categorias.AsQueryable()
            End Get
            Set(value As IQueryable(Of Categoria))
                Throw New InvalidOperationException
            End Set
        End Property

        Public Property Usuarios As IQueryable(Of Usuario) Implements IApplicationRepository.Usuarios
            Get
                Return context.Usuarios.AsQueryable()
            End Get
            Set(value As IQueryable(Of Usuario))
                Throw New InvalidOperationException
            End Set
        End Property

        Public Property Aplicaciones As IQueryable(Of Aplicacione) Implements IApplicationRepository.Aplicaciones
            Get
                Return context.Aplicaciones.AsQueryable()
            End Get
            Set(value As IQueryable(Of Aplicacione))
                Throw New InvalidOperationException
            End Set
        End Property

        'Public Sub Add(usuario As Usuario) Implements IApplicationRepository.Add
        '    context.Usuarios.Add(usuario)
        'End Sub

        'Public Sub Add(aplicacion As Aplicacione) Implements IApplicationRepository.Add
        '    context.Aplicaciones.Add(aplicacion)
        'End Sub

        Public Sub Add(Of T As Class)(entity As T) Implements IApplicationRepository.Add
            context.Set(Of T).Add(entity)
        End Sub

        Public Sub SaveChanges() Implements IApplicationRepository.SaveChanges
            context.SaveChanges()
        End Sub

        Public Function SaveChangesAsync() As Task Implements IApplicationRepository.SaveChangesAsync
            Return context.SaveChangesAsync()
        End Function
    End Class
End Namespace