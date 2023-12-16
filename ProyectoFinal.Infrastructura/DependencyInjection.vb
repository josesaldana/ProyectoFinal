Imports ProyectoFinal.Application
Imports SimpleInjector

Public Class DependencyInjection
    Public Shared Sub AddInfrastructure(ByVal container As Container)
        container.Register(Of Ds8ProyectofinalContext)(Lifestyle.Scoped)
        container.Register(Of ITrabajosRepository, SqlServerTrabajosRepository)(Lifestyle.Scoped)
    End Sub
End Class
