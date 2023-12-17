Imports ProyectoFinal.Domain
Imports ProyectoFinal.Domain.Ports
Imports ProyectoFinal.Infrastructura.Adapters
Imports SimpleInjector

Public Class DependencyInjection
    Public Shared Sub AddInfrastructure(ByVal container As Container)
        container.Register(Of Ds8ProyectofinalContext)(Lifestyle.Scoped)
        container.Register(Of ITrabajosRepository, SqlServerTrabajosRepository)(Lifestyle.Scoped)
        container.Register(Of IJobCategoryRepository, SqlServerJobCategoryRepository)(Lifestyle.Scoped)
    End Sub
End Class
