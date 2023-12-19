Imports System.Runtime.InteropServices
Imports ProyectoFinal.Domain.Agrupacion
Imports ProyectoFinal.Domain.Ports

Namespace UseCases
    Public Class AgruparTrabajosPorOficio
        Private repositorioDeAplicacion As IApplicationRepository

        Public Sub New(repositorioDeAplicacion As IApplicationRepository)
            Me.repositorioDeAplicacion = repositorioDeAplicacion
        End Sub

        Public Function Invocar() As List(Of GrupoDeCategoria)
            Dim grupos = repositorioDeAplicacion.Trabajos.AsEnumerable().
                GroupBy(Function(t) t.CategoriaId).
                OrderByDescending(Function(g) g.Count()).
                Select(Function(g) (IdCategoria:=g.Key, TotalCategoria:=g.Count())).
                ToList()

            Dim idsOficiosEnGrupos = grupos.Select(Function(g) g.IdCategoria)

            Dim oficios = repositorioDeAplicacion.Categorias.
                Where(Function(c) idsOficiosEnGrupos.Contains(c.Id)).
                ToDictionary(Function(c) c.Id)

            Return grupos.
                Select(Function(g)
                           Return New GrupoDeCategoria With {
                                     .Grupo = oficios(g.IdCategoria).Nombre,
                                     .Cantidad = g.TotalCategoria
                                 }
                       End Function).ToList()
        End Function
    End Class
End Namespace