Imports System.Runtime.CompilerServices
Imports ProyectoFinal.Application.UseCases
Imports SimpleInjector

Public Module DependencyInjection
    <Extension()>
    Public Sub AddApplication(ByVal container As Container)
        container.Register(Of BuscarTrabajo)(Lifestyle.Scoped)
        container.Register(Of AplicarVacante)(Lifestyle.Scoped)
        container.Register(Of AgruparTrabajosPorOficio)(Lifestyle.Scoped)
    End Sub
End Module