Imports ProyectoFinal.Domain

Public Class ConfigurarBusqueda
    Private repositoryDeCategorias As IJobCategoryRepository

    Public Sub New(repositoryDeCategorias As IJobCategoryRepository)
        Me.repositoryDeCategorias = repositoryDeCategorias
    End Sub

    Public Function Configurar(entrada As String) As Busqueda
        Dim jobCategories = repositoryDeCategorias.
            GetAllJobCategories().
            Select(Function(c) (New OpcionDeBusqueda With {
                .Name = c.Nombre,
                .Value = c.Id,
                .PreSelected = False
            })).
            ToList()

        Dim facetaDeCategorias = New FacetaDeBusqueda With {
            .Name = "Categorías",
            .Options = jobCategories,
            .Type = "Combo"
        }

        Return New Busqueda With {
            .TextoLibre = entrada,
            .Filtros = New List(Of FacetaDeBusqueda) From {facetaDeCategorias}
        }
    End Function
End Class
