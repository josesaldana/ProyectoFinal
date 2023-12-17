Imports System.Runtime.CompilerServices
Imports ProyectoFinal.Domain.Ports
Imports ProyectoFinal.Infrastructura.Adapters
Imports SimpleInjector

Public Module DependencyInjection

    <Extension()>
    Public Sub AddInfrastructure(ByVal container As Container)
        container.Register(Of Ds8ProyectofinalContext)(Lifestyle.Scoped)
        container.Register(Of IApplicationRepository, SqlServerApplicationRepository)(Lifestyle.Scoped)
    End Sub

End Module
