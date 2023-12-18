Public Class ExcepcionDeDominio
    Inherits Exception
    Sub New(msg As String)
        MyBase.New(msg)
    End Sub
End Class
