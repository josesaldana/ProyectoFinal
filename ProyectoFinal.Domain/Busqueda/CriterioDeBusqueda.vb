Public Class CriterioDeBusqueda
    Public Property Termino As String = "*"
    Public Property Categorias As List(Of Integer) = New List(Of Integer)
    Public Property Tipos As List(Of String) = New List(Of String)
    Public Property EntornosDeTrabajo As List(Of String) = New List(Of String)
    Public Property Paginacion As Paginacion = New Paginacion
End Class
