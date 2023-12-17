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
    End Class
End Namespace