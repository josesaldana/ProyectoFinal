Imports System.ComponentModel.Composition
Imports ProyectoFinal.Application.UseCases
Imports ProyectoFinal.Domain.Busqueda
Imports ProyectoFinal.Domain.Entities
Imports ProyectoFinal.Utils

Partial Class Search
    Inherits Page

    Private Const FiltroCategoriaSessionKey = "FiltroCategoriasSeleccionadas"
    Private Const FiltroTiposSessionKey = "FiltroTiposSeleccionados"
    Private Const FiltroEntornosSessionKey = "FiltroEntornosSeleccionados"

    Private resultadoDeBusqueda As ResultadoDeBusqueda(Of Trabajo)

    <Import()> Public Property buscarTrabajo As BuscarTrabajo

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim criterioDeBusqueda = New CriterioDeBusqueda With {
            .Termino = If(String.IsNullOrEmpty(Request("term")), "*", Request("term").Trim())
        }

        Dim filtrosDeBusqueda = New FiltrosDeBusqueda

        If IsPostBack Then
            ActualizarFiltrosDeBusqueda(filtrosDeBusqueda)
        End If

        resultadoDeBusqueda = buscarTrabajo.Invocar(criterioDeBusqueda, filtrosDeBusqueda)

        DivContenedorListaDeResultados.Visible = True

        LabelTotalDeResultados.Text = CType(resultadoDeBusqueda.Total, String)

        RepetidorDeResultados.DataSource = resultadoDeBusqueda.Resultados
        RepetidorDeResultados.DataBind()

        RepetidorDeFacetasDeBusqueda.DataSource = resultadoDeBusqueda.Filtros
        RepetidorDeFacetasDeBusqueda.DataBind()
    End Sub

    Private Sub ActualizarFiltrosDeBusqueda(filtrosDeBusqueda As FiltrosDeBusqueda)
        Dim filtroCategoriasSeleccionadas = If(
            Session.Keys.ToList().Contains(FiltroCategoriaSessionKey),
            CType(Session(FiltroCategoriaSessionKey), List(Of Integer)),
            New List(Of Integer))

        Dim filtroTiposSeleccionados = If(
            Session.Keys.ToList().Contains(FiltroTiposSessionKey),
            CType(Session(FiltroTiposSessionKey), List(Of String)),
            New List(Of String))

        Dim filtroEntornosSeleccionados = If(
            Session.Keys.ToList().Contains(FiltroEntornosSessionKey),
            CType(Session(FiltroEntornosSessionKey), List(Of String)),
            New List(Of String))

        Dim idDeControlDeFiltroSeleccionado = Request.Params.Get("__EVENTTARGET")
        Dim filtroOpcionRegexp = New Regex(".*filtro-(.*)-opcion-(.*)$").Match(idDeControlDeFiltroSeleccionado)
        Dim filtroSeleccionado = filtroOpcionRegexp.Groups(1).Value

        If filtroSeleccionado = "Categorías" Then
            Dim opcionSeleccionada = CType(filtroOpcionRegexp.Groups(2).Value, Integer)

            If filtroCategoriasSeleccionadas.Contains(opcionSeleccionada) Then
                filtroCategoriasSeleccionadas.Remove(opcionSeleccionada)
            Else
                filtroCategoriasSeleccionadas.Add(opcionSeleccionada)
            End If
        ElseIf filtroSeleccionado = "Tipos" Then
            Dim opcionSeleccionada = filtroOpcionRegexp.Groups(2).Value

            If filtroTiposSeleccionados.Contains(opcionSeleccionada) Then
                filtroTiposSeleccionados.Remove(opcionSeleccionada)
            Else
                filtroTiposSeleccionados.Add(opcionSeleccionada)
            End If
        ElseIf filtroSeleccionado = "Entornos" Then
            Dim opcionSeleccionada = filtroOpcionRegexp.Groups(2).Value

            If filtroEntornosSeleccionados.Contains(opcionSeleccionada) Then
                filtroEntornosSeleccionados.Remove(opcionSeleccionada)
            Else
                filtroEntornosSeleccionados.Add(opcionSeleccionada)
            End If
        End If

        filtrosDeBusqueda.Categorias = filtroCategoriasSeleccionadas
        filtrosDeBusqueda.Tipos = filtroTiposSeleccionados
        filtrosDeBusqueda.EntornosDeTrabajo = filtroEntornosSeleccionados

        Session(FiltroCategoriaSessionKey) = filtrosDeBusqueda.Categorias
        Session(FiltroTiposSessionKey) = filtrosDeBusqueda.Tipos
        Session(FiltroEntornosSessionKey) = filtrosDeBusqueda.EntornosDeTrabajo
    End Sub

    Protected Sub RepetidorDeFacetasDeBusqueda_OnItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles RepetidorDeFacetasDeBusqueda.ItemDataBound
        Dim placeholder As PlaceHolder = e.Item.FindControl("FiltrosItemControlPlaceholder")

        Dim filtro = CType(e.Item.DataItem, CategoriaDeFiltro)

        Dim labelTituloDeCategoriaDeFiltro = New Label() With {
            .ID = "filtro-" & filtro.Nombre,
            .Text = filtro.Nombre,
            .CssClass = "text-xl"
        }

        Dim filtroContainer = New Panel() With {
            .ID = "panel-filtro" & filtro.Nombre,
            .CssClass = "w-full"
        }
        filtroContainer.Controls.Add(labelTituloDeCategoriaDeFiltro)

        Dim opcionesDeFiltroContainer = New Panel() With {
            .ID = "panel-filtro-" & filtro.Nombre & "-opciones",
            .CssClass = "grid grid-cols-search-facets gap-x-2 gap-y-5 items-center mt-5"
        }

        For Each opcionDeFiltro In filtro.Opciones
            Dim checkboxOpcionDeFiltro = New CheckBox With {
                .ID = "filtro-" & filtro.Nombre & "-opcion-" & opcionDeFiltro.Value,
                .Text = opcionDeFiltro.Name
            }
            checkboxOpcionDeFiltro.InputAttributes.Add("class", "checkbox")
            checkboxOpcionDeFiltro.LabelAttributes.Add("class", "label-text")
            checkboxOpcionDeFiltro.AutoPostBack = True
            opcionesDeFiltroContainer.Controls.Add(checkboxOpcionDeFiltro)
        Next

        filtroContainer.Controls.Add(opcionesDeFiltroContainer)
        placeholder.Controls.Add(filtroContainer)
    End Sub
End Class

