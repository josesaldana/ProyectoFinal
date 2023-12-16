Imports System.Data.Entity
Imports ProyectoFinal.Application.Entities

Public Interface IDs8ProyectoFinalDbContext
    'Property Categorias As DbSet(Of Categoria)
    'Property Contratantes As DbSet(Of Contratante)
    'Property Trabajos As DbSet(Of Trabajo)
    Function GetTrabajos() As List(Of Trabajo)
End Interface
