Imports ProyectoFinal.Domain
Imports ProyectoFinal.Domain.Entities

Public Class SqlServerJobCategoryRepository
    Implements IJobCategoryRepository

    Private context As Ds8ProyectofinalContext

    Public Sub New(context As Ds8ProyectofinalContext)
        Me.context = context
    End Sub

    Public Function GetAllJobCategories() As List(Of Categoria) Implements IJobCategoryRepository.GetAllJobCategories
        Return context.Categorias.ToList()
    End Function
End Class
