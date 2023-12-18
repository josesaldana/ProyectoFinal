Imports ProyectoFinal.Application
Imports ProyectoFinal.Application.UseCases
Imports ProyectoFinal.Domain.Entities
Imports System.ComponentModel.Composition

Partial Class JobApplication
    Inherits System.Web.UI.Page

    <Import()> Public Property buscarTrabajo As BuscarTrabajo
    <Import()> Public Property aplicarVacante As AplicarVacante

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim detalleDeTrabajo = buscarTrabajo.Invocar(CType(Request("Vacante"), Integer))

            LabelTituloDeTrabajo.InnerText = detalleDeTrabajo.Titulo
            ParrafoDescripcionDeTrabajo.Text = detalleDeTrabajo.DescripcionCorta
        End If
    End Sub

    Protected Sub ButtonAplicar_Click(sender As Object, e As EventArgs)
        Dim usuario = New Usuario With {
            .Nombre = TextBoxNombre.Text,
            .Apellido = TextBoxApellido.Text,
            .Edad = If(String.IsNullOrEmpty(TextBoxEdad.Text), Nothing, CType(TextBoxEdad.Text, Integer)),
            .FechaDeNacimiento = If(String.IsNullOrEmpty(TextBoxFechaDeNacimiento.Text), Nothing, Date.Parse(TextBoxFechaDeNacimiento.Text)),
            .Telefono = TextBoxTelefono.Text,
            .Email = TextBoxEmail.Text,
            .Discriminador = "Aplicante"
        }

        Dim trabajo = New Trabajo With {
            .Id = CType(Request("Vacante"), Integer)
        }

        Dim aplicacion = New Aplicacione With {
            .Educacion = TextBoxEducacion.Text,
            .Habilidades = TextBoxHabilidades.Text,
            .Fecha = Now,
            .Experiencia = TextBoxExperiencia.Text,
            .HojaDeVida = If(FileUploadCV.HasFile, FileUploadCV.FileName, Nothing)
        }

        Try
            aplicarVacante.Invocar(usuario, trabajo, aplicacion)

            ContenedorDeFormualario.Visible = False
            ContenedorDeConfirmacion.Visible = True
        Catch ex As Exception
            LiteralErrorText.Text = ex.Message
            ContenedorDeError.Visible = True
        End Try
    End Sub
End Class
