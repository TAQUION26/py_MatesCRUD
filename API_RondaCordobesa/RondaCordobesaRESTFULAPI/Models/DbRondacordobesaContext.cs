using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RondaCordobesaRESTFULAPI.Models;

public partial class DbRondacordobesaContext : DbContext
{
    public DbRondacordobesaContext()
    {
    }

    public DbRondacordobesaContext(DbContextOptions<DbRondacordobesaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }

    public virtual DbSet<DetalleVenta> DetalleVentas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=TAQUION\\SQLSERVERMAX;Initial Catalog=db_rondacordobesa;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Idcategoria).HasName("PK__Categori__70E82E2872E7DF7C");

            entity.Property(e => e.Idcategoria).HasColumnName("IDCategoria");
            entity.Property(e => e.DescripcionCategoria).HasMaxLength(255);
            entity.Property(e => e.NombreCategoria).HasMaxLength(100);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Idcliente).HasName("PK__Clientes__9B8553FC17E3142B");

            entity.Property(e => e.Idcliente).HasColumnName("IDCliente");
            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.Ciudad).HasMaxLength(50);
            entity.Property(e => e.CodigoPostal).HasMaxLength(10);
            entity.Property(e => e.CorreoElectronico).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(100);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Provincia).HasMaxLength(50);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.Idcompra).HasName("PK__Compras__08719EC16C0D6627");

            entity.Property(e => e.Idcompra).HasColumnName("IDCompra");
            entity.Property(e => e.FechaCompra)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.Idproveedor).HasColumnName("IDProveedor");
            entity.Property(e => e.TotalCompra).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdproveedorNavigation).WithMany(p => p.Compras)
                .HasForeignKey(d => d.Idproveedor)
                .HasConstraintName("FK__Compras__IDProve__286302EC");
        });

        modelBuilder.Entity<DetalleCompra>(entity =>
        {
            entity.HasKey(e => e.IddetalleCompra).HasName("PK__DetalleC__DE482504C5AD0576");

            entity.Property(e => e.IddetalleCompra).HasColumnName("IDDetalleCompra");
            entity.Property(e => e.Idcompra).HasColumnName("IDCompra");
            entity.Property(e => e.Idproducto).HasColumnName("IDProducto");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Subtotal)
                .HasComputedColumnSql("([Cantidad]*[PrecioUnitario])", false)
                .HasColumnType("decimal(21, 2)");

            entity.HasOne(d => d.IdcompraNavigation).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.Idcompra)
                .HasConstraintName("FK__DetalleCo__IDCom__2B3F6F97");

            entity.HasOne(d => d.IdproductoNavigation).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.Idproducto)
                .HasConstraintName("FK__DetalleCo__IDPro__2C3393D0");
        });

        modelBuilder.Entity<DetalleVenta>(entity =>
        {
            entity.HasKey(e => e.IddetalleVenta).HasName("PK__DetalleV__DA9AFB79A4DBAD0D");

            entity.Property(e => e.IddetalleVenta).HasColumnName("IDDetalleVenta");
            entity.Property(e => e.Idproducto).HasColumnName("IDProducto");
            entity.Property(e => e.Idventa).HasColumnName("IDVenta");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Subtotal)
                .HasComputedColumnSql("([Cantidad]*[PrecioUnitario])", false)
                .HasColumnType("decimal(21, 2)");

            entity.HasOne(d => d.IdproductoNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.Idproducto)
                .HasConstraintName("FK__DetalleVe__IDPro__24927208");

            entity.HasOne(d => d.IdventaNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.Idventa)
                .HasConstraintName("FK__DetalleVe__IDVen__239E4DCF");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Idproducto).HasName("PK__Producto__ABDAF2B4523F1D58");

            entity.Property(e => e.Idproducto).HasColumnName("IDProducto");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.FechaIngreso)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.Idcategoria).HasColumnName("IDCategoria");
            entity.Property(e => e.NombreProducto).HasMaxLength(100);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdcategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.Idcategoria)
                .HasConstraintName("FK__Productos__IDCat__1B0907CE");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.Idproveedor).HasName("PK__Proveedo__4CD7324019290BE3");

            entity.Property(e => e.Idproveedor).HasColumnName("IDProveedor");
            entity.Property(e => e.Ciudad).HasMaxLength(50);
            entity.Property(e => e.CodigoPostal).HasMaxLength(10);
            entity.Property(e => e.CorreoElectronico).HasMaxLength(100);
            entity.Property(e => e.Direccion).HasMaxLength(100);
            entity.Property(e => e.NombreProveedor).HasMaxLength(100);
            entity.Property(e => e.Provincia).HasMaxLength(50);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.Idproducto).HasName("PK__Stock__ABDAF2B48DB9F36A");

            entity.ToTable("Stock");

            entity.Property(e => e.Idproducto)
                .ValueGeneratedNever()
                .HasColumnName("IDProducto");
            entity.Property(e => e.FechaActualizacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");

            entity.HasOne(d => d.IdproductoNavigation).WithOne(p => p.Stock)
                .HasForeignKey<Stock>(d => d.Idproducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Stock__IDProduct__300424B4");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.Idventa).HasName("PK__Ventas__27134B821B7CD0C6");

            entity.Property(e => e.Idventa).HasColumnName("IDVenta");
            entity.Property(e => e.FechaVenta)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date");
            entity.Property(e => e.Idcliente).HasColumnName("IDCliente");
            entity.Property(e => e.TotalVenta).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.Idcliente)
                .HasConstraintName("FK__Ventas__IDClient__20C1E124");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
