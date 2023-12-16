Public Class PageInitializerModule
    Implements IHttpModule

    Public Sub New()
    End Sub

    Public ReadOnly Property ModuleName() As String
        Get
            Return "PageInitializerModule"
        End Get
    End Property

    'Public Shared Sub Initialize()
    '    DynamicModuleUtility.RegisterModule(GetType(PageInitializerModule))
    'End Sub

    Public Sub Init(context As HttpApplication) Implements IHttpModule.Init
        AddHandler context.PreRequestHandlerExecute,
            Sub(sender As Object, e As EventArgs)
                Dim handler = context.Context.CurrentHandler
                If (Not handler Is Nothing) Then
                    Dim name = handler.GetType().Assembly.FullName
                    If (Not name.StartsWith("System.Web") And Not name.StartsWith("Microsoft")) Then
                        MyApplication.InitializeHandler(handler)
                    End If
                End If
            End Sub
    End Sub

    Public Sub Dispose() Implements IHttpModule.Dispose
        ' Do nothing
    End Sub
End Class