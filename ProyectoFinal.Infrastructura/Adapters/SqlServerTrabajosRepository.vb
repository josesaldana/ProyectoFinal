Imports ProyectoFinal.Domain
Imports ProyectoFinal.Domain.Entities
Imports ProyectoFinal.Domain.Ports

Namespace Adapters
    Public Class SqlServerTrabajosRepository
        Implements ITrabajosRepository

        Private context As Ds8ProyectofinalContext

        Public Sub New(context As Ds8ProyectofinalContext)
            Me.context = context
        End Sub

        Public Function ObtenerPorCriterioDeBusqueda(criterio As CriterioDeBusqueda) As (Integer, List(Of Trabajo)) Implements ITrabajosRepository.ObtenerPorCriterioDeBusqueda
            Dim queryDeTermino = If(
                criterio.Termino = "*",
                Function(trabajo As Trabajo) True,
                Function(trabajo As Trabajo) trabajo.Titulo.ToLower().Contains(criterio.Termino.ToLower()))

            Dim queryDeCategorias = Function(trabajo As Trabajo) criterio.Categorias.Count = 0 Or criterio.Categorias.Contains(trabajo.CategoriaId)
            Dim queryDeTipos = Function(trabajo As Trabajo) criterio.Tipos.Count = 0 Or criterio.Tipos.Contains(trabajo.CategoriaId)
            Dim queryDeEntornosDeTrabajo = Function(trabajo As Trabajo) criterio.EntornosDeTrabajo.Count = 0 Or criterio.EntornosDeTrabajo.Contains(trabajo.CategoriaId)

            Dim registros = context.Trabajos.
                Where(queryDeTermino).
                Where(queryDeCategorias).
                Where(queryDeTipos).
                Where(queryDeEntornosDeTrabajo)

            Dim total = registros.Count()

            Dim resultado = registros.
                Skip(criterio.Paginacion.Pagina * criterio.Paginacion.TamanoDePagina).
                Take(criterio.Paginacion.TamanoDePagina).
                ToList()

            Return (total, resultado)
        End Function
    End Class
End Namespace