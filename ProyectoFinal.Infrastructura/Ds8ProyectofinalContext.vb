Imports System
Imports System.Collections.Generic
Imports Microsoft.EntityFrameworkCore
Imports ProyectoFinal.Domain.Entities
Imports ProyectoFinal.Domain.Ports

Partial Public Class Ds8ProyectofinalContext
    Inherits DbContext

    Public Sub New()
    End Sub

    'Public Sub New(options As DbContextOptions(Of Ds8ProyectofinalContext))
    '    MyBase.New(options)
    'End Sub

    Public Overridable Property Aplicaciones As DbSet(Of Aplicacione)

    Public Overridable Property Categorias As DbSet(Of Categoria)

    Public Overridable Property Contratantes As DbSet(Of Contratante)

    Public Overridable Property Trabajos As DbSet(Of Trabajo)

    Public Overridable Property Usuarios As DbSet(Of Usuario)

    Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=ds8-proyectofinal;Integrated Security=SSPI;TrustServerCertificate=True")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As ModelBuilder)
        modelBuilder.Entity(Of Aplicacione)(
                Sub(entity)
                    entity.HasKey(Function(e) e.Id).HasName("PK__Aplicaci__3214EC07989F088D")

                    entity.Property(Function(e) e.Educacion).IsRequired()
                    entity.Property(Function(e) e.Experiencia).IsRequired()
                    entity.Property(Function(e) e.Fecha).
                        HasDefaultValueSql("(getdate())").
                        HasColumnType("datetime")
                    entity.Property(Function(e) e.Habilidades).IsRequired()
                    entity.Property(Function(e) e.HojaDeVida).
                        HasMaxLength(1024).
                        IsUnicode(False)

                    entity.HasOne(Function(d) d.Aplicante).WithMany(Function(p) p.Aplicaciones).
                        HasForeignKey(Function(d) d.AplicanteId).
                        OnDelete(DeleteBehavior.ClientSetNull).
                        HasConstraintName("FK__Aplicacio__Aplic__5C37ACAD")

                    entity.HasOne(Function(d) d.Trabajo).WithMany(Function(p) p.Aplicaciones).
                        HasForeignKey(Function(d) d.TrabajoId).
                        OnDelete(DeleteBehavior.ClientSetNull).
                        HasConstraintName("FK__Aplicacio__Traba__5B438874")
                End Sub)

        modelBuilder.Entity(Of Categoria)(
                Sub(entity)
                    entity.HasKey(Function(e) e.Id).HasName("PK__Categori__3214EC0775BD49EA")

                    entity.Property(Function(e) e.Nombre).
                        IsRequired().
                        HasMaxLength(50).
                        IsUnicode(False)
                End Sub)

        modelBuilder.Entity(Of Contratante)(
                Sub(entity)
                    entity.HasKey(Function(e) e.Id).HasName("PK__Contrata__3214EC070D4193F4")

                    entity.Property(Function(e) e.Nombre).
                        IsRequired().
                        HasMaxLength(250).
                        IsUnicode(False)
                    entity.Property(Function(e) e.Tipo).
                        IsRequired().
                        HasMaxLength(50).
                        IsUnicode(False)
                End Sub)

        modelBuilder.Entity(Of Trabajo)(
                Sub(entity)
                    entity.HasKey(Function(e) e.Id).HasName("PK__Trabajos__3214EC07E6244D09")

                    entity.Property(Function(e) e.Abierto).
                        IsRequired().
                        HasDefaultValueSql("((1))")
                    entity.Property(Function(e) e.DescripcionCompleta).IsRequired()
                    entity.Property(Function(e) e.DescripcionCompletaSanitizado).IsRequired()
                    entity.Property(Function(e) e.DescripcionCorta).IsRequired()
                    entity.Property(Function(e) e.EntornoDeTrabajo).
                        HasMaxLength(20).
                        IsUnicode(False)
                    entity.Property(Function(e) e.FechaDePublicacion).
                        HasDefaultValueSql("(getdate())").
                        HasColumnType("date")
                    entity.Property(Function(e) e.Tipo).
                        HasMaxLength(20).
                        IsUnicode(False)
                    entity.Property(Function(e) e.Titulo).
                        IsRequired().
                        HasMaxLength(500).
                        IsUnicode(False)
                    entity.Property(Function(e) e.Ubicacion).
                        HasMaxLength(250).
                        IsUnicode(False)

                    entity.HasOne(Function(d) d.Categoria).WithMany(Function(p) p.Trabajos).
                        HasForeignKey(Function(d) d.CategoriaId).
                        OnDelete(DeleteBehavior.ClientSetNull).
                        HasConstraintName("FK__Trabajos__Catego__51BA1E3A")

                    entity.HasOne(Function(d) d.Contratante).WithMany(Function(p) p.Trabajos).
                        HasForeignKey(Function(d) d.ContratanteId).
                        OnDelete(DeleteBehavior.ClientSetNull).
                        HasConstraintName("FK__Trabajos__Contra__52AE4273")
                End Sub)

        modelBuilder.Entity(Of Usuario)(
                Sub(entity)
                    entity.HasKey(Function(e) e.Id).HasName("PK__Usuarios__3214EC074E6E4107")

                    entity.HasIndex(Function(e) e.Email).IsUnique()

                    entity.Property(Function(e) e.Apellido).
                        IsRequired().
                        HasMaxLength(250).
                        IsUnicode(False)
                    entity.Property(Function(e) e.Discriminador).
                        IsRequired().
                        HasMaxLength(50).
                        IsUnicode(False)
                    entity.Property(Function(e) e.Email).
                        HasMaxLength(250).
                        IsUnicode(False)
                    entity.Property(Function(e) e.FechaDeNacimiento).HasColumnType("date")
                    entity.Property(Function(e) e.Nombre).
                        IsRequired().
                        HasMaxLength(250).
                        IsUnicode(False)
                    entity.Property(Function(e) e.Telefono).
                        IsRequired().
                        HasMaxLength(50).
                        IsUnicode(False)
                End Sub)

        OnModelCreatingPartial(modelBuilder)
    End Sub

    Partial Private Sub OnModelCreatingPartial(modelBuilder As ModelBuilder)
    End Sub
End Class
