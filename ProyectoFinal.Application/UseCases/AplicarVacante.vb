Imports ProyectoFinal.Domain
Imports ProyectoFinal.Domain.Entities
Imports ProyectoFinal.Domain.Ports

Public Class AplicarVacante
    Private repositorioDeAplicacion As IApplicationRepository

    Public Sub New(repositorioDeAplicacion As IApplicationRepository)
        Me.repositorioDeAplicacion = repositorioDeAplicacion
    End Sub

    Public Async Sub Invocar(usuario As Usuario, trabajo As Trabajo, aplicacion As Aplicacione)
        Dim usuarioRegistrado = (
            From u In repositorioDeAplicacion.Usuarios
            Where u.Email.Contains(usuario.Email)
            Select u).SingleOrDefault()

        If (usuarioRegistrado Is Nothing) Then
            repositorioDeAplicacion.Add(usuario)
            Await repositorioDeAplicacion.SaveChangesAsync()

            usuarioRegistrado = usuario
        End If

        Dim trabajoRegistrado = repositorioDeAplicacion.Trabajos.FirstOrDefault(Function(t) t.Id = trabajo.Id)

        If trabajoRegistrado Is Nothing Then
            Throw New ExcepcionDeDominio("El trabajo especificado no es válido")
        End If

        aplicacion.TrabajoId = trabajoRegistrado.Id
        aplicacion.AplicanteId = usuarioRegistrado.Id

        repositorioDeAplicacion.Add(aplicacion)
        Await repositorioDeAplicacion.SaveChangesAsync()
    End Sub
End Class
