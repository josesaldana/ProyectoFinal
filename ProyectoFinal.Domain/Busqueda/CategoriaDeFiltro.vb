Namespace Busqueda
    Public Class CategoriaDeFiltro
        Public Nombre As String
        Public Opciones As List(Of OpcionDeFiltro)
        Public Tipo As String
    End Class

    Public Class OpcionDeFiltro
        Public Property Name As String
        Public Property Value As Object
        Public Property PreSelected As Boolean
    End Class
End Namespace