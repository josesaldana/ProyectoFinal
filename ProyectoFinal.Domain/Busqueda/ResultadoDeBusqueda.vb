Namespace Busqueda
    Public Class ResultadoDeBusqueda(Of Entidad)
        Public Property Resultados As List(Of Entidad)
        Public Property Total As Integer
        Public Property Filtros As List(Of CategoriaDeFiltro)
        Public Property CriterioUtilizado As CriterioDeBusqueda
    End Class

    Public Class Paginacion
        Public Property Pagina As Integer = 0
        Public Property TamanoDePagina As Integer = 50
    End Class
End Namespace