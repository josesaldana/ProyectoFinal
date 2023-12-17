Imports Microsoft.EntityFrameworkCore
Imports ProyectoFinal.Domain.Entities

Partial Public Class Ds8ProyectofinalContext
    Inherits DbContext

    Public Sub New()
    End Sub

    'Public Sub New(options As DbContextOptions(Of Ds8ProyectofinalContext))
    '    MyBase.New(options)
    'End Sub

    Public Overridable Property Categorias As DbSet(Of Categoria)

    Public Overridable Property Contratantes As DbSet(Of Contratante)

    Public Overridable Property Trabajos As DbSet(Of Trabajo)

    Protected Overrides Sub OnConfiguring(optionsBuilder As DbContextOptionsBuilder)
        'TODO /!\ To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=ds8-proyectofinal;Integrated Security=SSPI;TrustServerCertificate=True")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As ModelBuilder)
        modelBuilder.Entity(Of Categoria)(
                Sub(entity)
                    entity.HasKey(Function(e) e.Id).HasName("PK__Categori__3214EC07E3C4F211")

                    entity.Property(Function(e) e.Nombre).
                        IsRequired().
                        HasMaxLength(50).
                        IsUnicode(False)
                End Sub)

        modelBuilder.Entity(Of Contratante)(
                Sub(entity)
                    entity.HasKey(Function(e) e.Id).HasName("PK__Contrata__3214EC0793864A81")

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
                    entity.HasKey(Function(e) e.Id).HasName("PK__Trabajos__3214EC07DA38F3F8")

                    entity.Property(Function(e) e.Abierto).
                        IsRequired().
                        HasDefaultValueSql("((1))")
                    entity.Property(Function(e) e.DescripcionCorta).IsRequired()
                    entity.Property(Function(e) e.DescripcionCompleta).IsRequired()
                    entity.Property(Function(e) e.DescripcionCompletaSanitizado).IsRequired()
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
                        HasConstraintName("FK__Trabajos__Catego__3A4CA8FD")

                    entity.HasOne(Function(d) d.Contratante).WithMany(Function(p) p.Trabajos).
                        HasForeignKey(Function(d) d.ContratanteId).
                        OnDelete(DeleteBehavior.ClientSetNull).
                        HasConstraintName("FK__Trabajos__Contra__3B40CD36")
                End Sub)

        OnModelCreatingPartial(modelBuilder)
    End Sub

    Partial Private Sub OnModelCreatingPartial(modelBuilder As ModelBuilder)
    End Sub

End Class
