Imports ProyectoFinal.Domain.Entities
Imports ProyectoFinal.Domain.Ports
Imports ProyectoFinal.Domain.Busqueda

Namespace UseCases
    Public Class BuscarTrabajo
        Private repositorioDeAplicacion As IApplicationRepository

        Public Sub New(repositorioDeAplicacion As IApplicationRepository)
            Me.repositorioDeAplicacion = repositorioDeAplicacion
        End Sub

        Public Function Invocar(id As Integer) As Trabajo
            Return repositorioDeAplicacion.Trabajos.FirstOrDefault(Function(t) t.Id = id)
        End Function

        Public Function Invocar(criterio As CriterioDeBusqueda, filtros As FiltrosDeBusqueda) As ResultadoDeBusqueda(Of Trabajo)
            Dim matchesTermino = If(
                criterio.Termino = "*",
                Function(trabajo As Trabajo) True,
                Function(trabajo As Trabajo)
                    Return trabajo.Titulo.ToLower().Contains(criterio.Termino.ToLower()) Or
                    trabajo.DescripcionCompletaSanitizado.ToLower().Contains(criterio.Termino.ToLower())
                End Function)

            Dim matchesCategorias =
                Function(trabajo As Trabajo)
                    Return filtros.Categorias.Count = 0 Or filtros.Categorias.Contains(trabajo.CategoriaId)
                End Function

            Dim matchesTipos =
                Function(trabajo As Trabajo)
                    Return filtros.Tipos.Count = 0 Or filtros.Tipos.Contains(trabajo.Tipo)
                End Function

            Dim matchesEntornosDeTrabajo =
                Function(trabajo As Trabajo)
                    Return filtros.EntornosDeTrabajo.Count = 0 Or filtros.EntornosDeTrabajo.Contains(trabajo.EntornoDeTrabajo)
                End Function

            Dim trabajosEncontrados = repositorioDeAplicacion.Trabajos.
                Where(matchesTermino).
                Where(matchesCategorias).
                Where(matchesTipos).
                Where(matchesEntornosDeTrabajo)

            Dim total = trabajosEncontrados.Count()

            Dim diccionarioDeCategoriasExistentes = repositorioDeAplicacion.Categorias.ToDictionary(Function(c) c.Id, Function(c) c)

            Dim filtrosDeCategoriasPorResultados = trabajosEncontrados.
                Select(Function(trabajo) trabajo.CategoriaId).
                Distinct().
                OrderBy(Function(c) c).
                Select(Function(t) New OpcionDeFiltro With {.Name = diccionarioDeCategoriasExistentes(t).Nombre, .Value = t})

            Dim filtroDeTiposPorResultados = trabajosEncontrados.
                Select(Function(trabajo) trabajo.Tipo).
                Distinct().
                OrderBy(Function(t) t).
                Select(Function(t) New OpcionDeFiltro With {.Name = t, .Value = t})

            Dim filtroDeEntornosDeTrabajoPorResultados = trabajosEncontrados.
                Select(Function(trabajo) trabajo.EntornoDeTrabajo).
                Distinct().
                OrderBy(Function(e) e).
                Select(Function(t) New OpcionDeFiltro With {.Name = t, .Value = t})

            Dim filtrosPorResultados = New List(Of CategoriaDeFiltro) From {
                    New CategoriaDeFiltro With {
                        .Nombre = "Categorías",
                        .Opciones = filtrosDeCategoriasPorResultados.ToList()
                    },
                    New CategoriaDeFiltro With {
                        .Nombre = "Tipos",
                        .Opciones = filtroDeTiposPorResultados.ToList()
                    },
                    New CategoriaDeFiltro With {
                        .Nombre = "Entornos",
                        .Opciones = filtroDeEntornosDeTrabajoPorResultados.ToList()
                    }
                }

            Dim resultadosSolicitados = trabajosEncontrados.
                Skip(criterio.Paginacion.Pagina * criterio.Paginacion.TamanoDePagina).
                Take(criterio.Paginacion.TamanoDePagina).
                ToList()

            Return New ResultadoDeBusqueda(Of Trabajo) With {
                .Resultados = resultadosSolicitados,
                .Total = total,
                .Filtros = filtrosPorResultados,
                .CriterioUtilizado = criterio
            }
        End Function
    End Class
End Namespace
