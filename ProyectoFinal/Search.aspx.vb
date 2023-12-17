Imports System.ComponentModel.Composition
Imports ProyectoFinal.Application
Imports ProyectoFinal.Application.UseCases
Imports ProyectoFinal.Domain
Imports ProyectoFinal.Domain.Entities

Partial Class Search
    Inherits System.Web.UI.Page

    Private busqueda As Busqueda

    <Import()> Public Property buscarTrabajoUseCase As BuscarTrabajo
    <Import()> Public Property configurarBusquedaUseCase As ConfigurarBusqueda

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim criterioDeBusqueda = New CriterioDeBusqueda With {
                .Termino = If(String.IsNullOrEmpty(Request("term")), "*", Request("term").Trim())
            }

            Dim resultados = buscarTrabajoUseCase.Buscar(criterioDeBusqueda)

            DivContenedorListaDeResultados.Visible = True

            LabelTotalDeResultados.Text = CType(resultados.Total, String)

            RepetidorDeResultados.DataSource = resultados.Resultados
            RepetidorDeResultados.DataBind()

            busqueda = configurarBusquedaUseCase.Configurar(criterioDeBusqueda)
            RepetidorDeFacetasDeBusqueda.DataSource = busqueda.Filtros
            RepetidorDeFacetasDeBusqueda.DataBind()
        End If
    End Sub

    Protected Sub RepetidorDeFacetasDeBusqueda_OnItemDataBound(sender As Object, e As RepeaterItemEventArgs) Handles RepetidorDeFacetasDeBusqueda.ItemDataBound
        Dim placeholder As PlaceHolder = e.Item.FindControl("FacetasDeBusquedaItemControlPlaceholder")

        Dim facetaDeBusqueda = CType(e.Item.DataItem, CategoriaDeBusqueda)

        Dim indexDeFaceta = busqueda.Filtros.FindIndex(Function(p As CategoriaDeBusqueda) p.Name = facetaDeBusqueda.Name)
        Dim labelTituloDeFacteta = New Label() With {.ID = "Faceta" & indexDeFaceta, .Text = facetaDeBusqueda.Name, .CssClass = "text-xl"}

        Dim facetaContainer = New Panel() With {.ID = "PanelOpcionesDeFaceta" & indexDeFaceta, .CssClass = "w-full"}
        facetaContainer.Controls.Add(labelTituloDeFacteta)

        Dim opcionesDeBusquedaContainer = New Panel() With {
            .ID = "PanelPregunta" & indexDeFaceta & "-respuestas",
            .CssClass = "grid grid-cols-search-facets gap-x-2 gap-y-5 items-center mt-5"
        }

        For Each opcionDeBusqueda In facetaDeBusqueda.Options
            Dim checkboxParaOpcionDeBusqueda = New CheckBox With {
                .ID = indexDeFaceta & "-" & facetaDeBusqueda.Options.IndexOf(opcionDeBusqueda),
                .Text = opcionDeBusqueda.Name
            }
            checkboxParaOpcionDeBusqueda.InputAttributes.Add("class", "checkbox")
            checkboxParaOpcionDeBusqueda.LabelAttributes.Add("class", "label-text")
            checkboxParaOpcionDeBusqueda.AutoPostBack = True
            'AddHandler respuestaOptionsList.SelectedIndexChanged, AddressOf CategoriaSeleccionada
            opcionesDeBusquedaContainer.Controls.Add(checkboxParaOpcionDeBusqueda)
        Next


        facetaContainer.Controls.Add(opcionesDeBusquedaContainer)
        placeholder.Controls.Add(facetaContainer)
    End Sub
End Class

