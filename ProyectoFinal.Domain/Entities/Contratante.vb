Imports System
Imports System.Collections.Generic

Namespace Entities
    Partial Public Class Contratante
        Public Property Id As Integer

        Public Property Nombre As String

        Public Property Tipo As String

        Public Property Direccion As String

        Public Property Contacto As String

        Public Overridable ReadOnly Property Trabajos As ICollection(Of Trabajo) = New List(Of Trabajo)()
    End Class
End Namespace
