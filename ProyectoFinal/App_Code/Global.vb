Imports System.Reflection
Imports System.Web.Routing
Imports SimpleInjector
Imports SimpleInjector.Advanced
Imports SimpleInjector.Diagnostics
Imports SimpleInjector.Integration.Web

Public Class MyApplication
    Inherits HttpApplication

    Private Shared container As Container

    Sub Application_Start(sender As Object, e As EventArgs)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)
        Bootstrap()
    End Sub

    Public Shared Sub InitializeHandler(handler As IHttpHandler)
        Dim handlerType = If(TypeOf handler Is Page, handler.GetType().BaseType, handler.GetType())
        container.GetRegistration(handlerType, True).Registration.InitializeInstance(handler)
    End Sub

    Public Shared Sub Bootstrap()
        Dim container = New Container()

        container.Options.DefaultScopedLifestyle = New WebRequestLifestyle()
        container.Options.ResolveUnregisteredConcreteTypes = True
        container.Options.PropertySelectionBehavior = New ImportAttributePropertySelectionBehavior()

        ProyectoFinal.Infrastructura.DependencyInjection.AddInfrastructure(container)
        ProyectoFinal.Application.DependencyInjection.AddApplication(container)

        RegisterWebPages(container)

        MyApplication.container = container

        container.Verify()
    End Sub

    Public Shared Sub RegisterWebPages(container As Container)
        'Dim pageTypes =
        '        From assembly In BuildManager.GetReferencedAssemblies().Cast(Of Assembly)()
        '        Where Not assembly.IsDynamic
        '        Where Not assembly.GlobalAssemblyCache
        '        From type In assembly.GetExportedTypes()
        '        Where type.IsSubclassOf(GetType(Page))
        '        Where Not type.IsAbstract And Not type.IsGenericType
        '        Select type

        Dim pageTypes =
            From type In GetType(MyApplication).Assembly.DefinedTypes
            Where type.IsSubclassOf(GetType(Page))
            Where Not type.IsAbstract And Not type.IsGenericType
            Select type

        For Each type As Type In pageTypes
            Dim reg = Lifestyle.Transient.CreateRegistration(type, container)
            reg.SuppressDiagnosticWarning(
                DiagnosticType.DisposableTransientComponent,
                "ASP.NET creates and disposes page classes for us.")
            container.AddRegistration(type, reg)
        Next
    End Sub

    Class ImportAttributePropertySelectionBehavior
        Implements IPropertySelectionBehavior

        Public Function IPropertySelectionBehavior_SelectProperty(implementationType As Type, propertyInfo As PropertyInfo) As Boolean Implements IPropertySelectionBehavior.SelectProperty
            Return GetType(Page).IsAssignableFrom(implementationType) And propertyInfo.GetCustomAttributes(GetType(System.ComponentModel.Composition.ImportAttribute), True).Any()
        End Function
    End Class
End Class
