using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplicationMVC02.Models;

public partial class PachacamacContext : DbContext
{
    public PachacamacContext()
    {
    }

    public PachacamacContext(DbContextOptions<PachacamacContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetPed> DetPeds { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Paise> Paises { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<Transporte> Transportes { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=.;database=Pachacamac;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Categorías");

            entity.Property(e => e.ArchivoImagen)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descrip).HasColumnType("ntext");
            entity.Property(e => e.Nombre).HasMaxLength(15);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.Property(e => e.CargoCont).HasMaxLength(30);
            entity.Property(e => e.Ciudad).HasMaxLength(15);
            entity.Property(e => e.Codigo).HasMaxLength(5);
            entity.Property(e => e.Contacto).HasMaxLength(30);
            entity.Property(e => e.Cpostal)
                .HasMaxLength(10)
                .HasColumnName("CPostal");
            entity.Property(e => e.Dire).HasMaxLength(60);
            entity.Property(e => e.Fax).HasMaxLength(24);
            entity.Property(e => e.Nombre).HasMaxLength(40);
            entity.Property(e => e.Region).HasMaxLength(15);
            entity.Property(e => e.Te)
                .HasMaxLength(24)
                .HasColumnName("TE");

            entity.HasOne(d => d.IdPaisesNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.IdPaises)
                .HasConstraintName("FK_Clientes_Paises");
        });

        modelBuilder.Entity<DetPed>(entity =>
        {
            entity.Property(e => e.PrecioUnidad).HasColumnType("money");

            entity.HasOne(d => d.IdPedidosNavigation).WithMany(p => p.DetPeds)
                .HasForeignKey(d => d.IdPedidos)
                .HasConstraintName("FK_DetPeds_Pedidos");

            entity.HasOne(d => d.IdProductosNavigation).WithMany(p => p.DetPeds)
                .HasForeignKey(d => d.IdProductos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetPeds_Productos");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.Property(e => e.Apellidos).HasMaxLength(20);
            entity.Property(e => e.Cargo).HasMaxLength(30);
            entity.Property(e => e.Ciudad).HasMaxLength(15);
            entity.Property(e => e.Cpostal)
                .HasMaxLength(10)
                .HasColumnName("CPostal");
            entity.Property(e => e.Dire).HasMaxLength(60);
            entity.Property(e => e.Exten).HasMaxLength(4);
            entity.Property(e => e.FechaContrat).HasColumnType("smalldatetime");
            entity.Property(e => e.FechaNac).HasColumnType("smalldatetime");
            entity.Property(e => e.Nombre).HasMaxLength(10);
            entity.Property(e => e.Notas).HasColumnType("ntext");
            entity.Property(e => e.Pais).HasMaxLength(15);
            entity.Property(e => e.Region).HasMaxLength(15);
            entity.Property(e => e.TelDomicilio).HasMaxLength(24);
            entity.Property(e => e.Tratamiento).HasMaxLength(25);
        });

        modelBuilder.Entity<Paise>(entity =>
        {
            entity.Property(e => e.CodEnTransportes)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Pais).HasMaxLength(15);
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.Property(e => e.Cargo).HasColumnType("money");
            entity.Property(e => e.CiudadDest).HasMaxLength(15);
            entity.Property(e => e.CpostalDes)
                .HasMaxLength(10)
                .HasColumnName("CPostalDes");
            entity.Property(e => e.Destinatario).HasMaxLength(40);
            entity.Property(e => e.DirDestinatario).HasMaxLength(60);
            entity.Property(e => e.FechaEntr).HasColumnType("smalldatetime");
            entity.Property(e => e.FechaEnv).HasColumnType("smalldatetime");
            entity.Property(e => e.FechaPed).HasColumnType("smalldatetime");
            entity.Property(e => e.RegDestinatario).HasMaxLength(15);

            entity.HasOne(d => d.IdClientesNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdClientes)
                .HasConstraintName("FK_Pedidos_Clientes");

            entity.HasOne(d => d.IdEmpleadosNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdEmpleados)
                .HasConstraintName("FK_Pedidos_Empleados");

            entity.HasOne(d => d.IdPaisesNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdPaises)
                .HasConstraintName("FK_Pedidos_Paises");

            entity.HasOne(d => d.IdTransportesNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdTransportes)
                .HasConstraintName("FK_Pedidos_Transportes");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.Property(e => e.CantidadPorUnidad).HasMaxLength(20);
            entity.Property(e => e.NombreProducto).HasMaxLength(40);
            entity.Property(e => e.PrecioUnidad).HasColumnType("money");

            entity.HasOne(d => d.IdCategoríasNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategorías)
                .HasConstraintName("FK_Productos_Categorías");

            entity.HasOne(d => d.IdProveedoresNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdProveedores)
                .HasConstraintName("FK_Productos_Proveedores");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.Property(e => e.CargoContacto).HasMaxLength(30);
            entity.Property(e => e.Ciudad).HasMaxLength(15);
            entity.Property(e => e.Contacto).HasMaxLength(30);
            entity.Property(e => e.Cpostal)
                .HasMaxLength(10)
                .HasColumnName("CPostal");
            entity.Property(e => e.Direc).HasMaxLength(60);
            entity.Property(e => e.Fax).HasMaxLength(24);
            entity.Property(e => e.Nombre).HasMaxLength(40);
            entity.Property(e => e.PagPrincipal).HasColumnType("ntext");
            entity.Property(e => e.Pais).HasMaxLength(15);
            entity.Property(e => e.Region).HasMaxLength(15);
            entity.Property(e => e.Te)
                .HasMaxLength(24)
                .HasColumnName("TE");
        });

        modelBuilder.Entity<Transporte>(entity =>
        {
            entity.Property(e => e.Nombre).HasMaxLength(40);
            entity.Property(e => e.Te)
                .HasMaxLength(24)
                .HasColumnName("TE");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Usuario1).HasName("PK_Usuario");

            entity.Property(e => e.Usuario1)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Usuario");
            entity.Property(e => e.Clave)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NombreyApellidos)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
