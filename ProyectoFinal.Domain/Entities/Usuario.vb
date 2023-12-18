Imports System
Imports System.Collections.Generic

Namespace Entities
    Partial Public Class Usuario
        Public Property Id As Long

        Public Property Nombre As String

        Public Property Apellido As String

        Public Property Edad As Integer?

        Public Property FechaDeNacimiento As Date?

        Public Property Telefono As String

        Public Property Email As String

        Public Property Discriminador As String

        Public Overridable ReadOnly Property Aplicaciones As ICollection(Of Aplicacione) = New List(Of Aplicacione)()
    End Class
End Namespace
