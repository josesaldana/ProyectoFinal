Imports System
Imports System.Collections.Generic

Namespace Entities
    Partial Public Class Trabajo
        Public Property Id As Long

        Public Property Titulo As String

        Public Property Descripcion As String

        Public Property DescripcionSanitizado As String

        Public Property CategoriaId As Integer

        Public Property ContratanteId As Integer

        Public Property Ubicacion As String

        Public Property Tipo As String

        Public Property EntornoDeTrabajo As String

        Public Property Abierto As Boolean?

        Public Property FechaDePublicacion As Date?

        Public Overridable Property Categoria As Categoria

        Public Overridable Property Contratante As Contratante
    End Class
End Namespace
