Imports System.Runtime.CompilerServices
Imports ProyectoFinal.Application.UseCases
Imports SimpleInjector

'Module DependencyInjection
'    <Extension()>
'    Public Sub AddApplication(ByVal container As Container)
'        container.Register(Of BuscarTrabajoUseCase)(Lifestyle.Scoped)
'    End Sub
'End Module

Public Class DependencyInjection
    Public Shared Sub AddApplication(ByVal container As Container)
        container.Register(Of BuscarTrabajo)(Lifestyle.Scoped)
        container.Register(Of ConfigurarBusqueda)(Lifestyle.Scoped)
    End Sub
End Class
