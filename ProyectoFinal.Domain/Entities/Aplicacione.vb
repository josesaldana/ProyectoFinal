Imports System
Imports System.Collections.Generic

Namespace Entities
    Partial Public Class Aplicacione
        Public Property Id As Long

        Public Property AplicanteId As Long

        Public Property TrabajoId As Long

        Public Property Fecha As Date?

        Public Property Educacion As String

        Public Property Habilidades As String

        Public Property Experiencia As String

        Public Property HojaDeVida As String

        Public Overridable Property Aplicante As Usuario

        Public Overridable Property Trabajo As Trabajo
    End Class
End Namespace
