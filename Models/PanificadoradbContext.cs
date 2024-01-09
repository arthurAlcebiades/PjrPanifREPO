using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PrjPanifMVC.Models;

public partial class PanificadoradbContext : DbContext
{
    public PanificadoradbContext()
    {
    }

    public PanificadoradbContext(DbContextOptions<PanificadoradbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbCliente> TbClientes { get; set; }

    public virtual DbSet<TbItemPedido> TbItemPedidos { get; set; }

    public virtual DbSet<TbMotoristum> TbMotorista { get; set; }

    public virtual DbSet<TbPedido> TbPedidos { get; set; }

    public virtual DbSet<TbProduto> TbProdutos { get; set; }

    public virtual DbSet<TbRotum> TbRota { get; set; }

    public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("User ID=postgres;Password=@Alcebiades12;Host=localhost;Port=5432;Database=PrjPaniDb;Pooling=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbCliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente);

            entity.ToTable("TB_CLIENTE");

            entity.Property(e => e.IdCliente)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id_Cliente");
            entity.Property(e => e.CpfCnpj)
                .HasMaxLength(18)
                .IsUnicode(false);
            entity.Property(e => e.EnderecoBairro)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EnderecoCidade)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EnderecoCliente)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EnderecoComplemento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EnderecoUf)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.NomeCliente)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TelefoneContatoCliente)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbItemPedido>(entity =>
        {
            entity.HasKey(e => e.IdItemPedido);

            entity.ToTable("TB_ITEM_PEDIDO");

            entity.Property(e => e.IdItemPedido)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id_ItemPedido");
            entity.Property(e => e.IdPedido).HasColumnName("Id_Pedido");
            entity.Property(e => e.IdProduto).HasColumnName("Id_Produto");
            entity.Property(e => e.ValorDesconto).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ValorTotal).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ValorUnitario).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdPedidoNavigation).WithMany(p => p.TbItemPedidos)
                .HasForeignKey(d => d.IdPedido)
                .HasConstraintName("FK_TB_ITEM_PEDIDO_TB_PEDIDO");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.TbItemPedidos)
                .HasForeignKey(d => d.IdProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_ITEM_PEDIDO_TB_Produtos");
        });

        modelBuilder.Entity<TbMotoristum>(entity =>
        {
            entity.HasKey(e => e.IdMotorista);

            entity.ToTable("TB_MOTORISTA");

            entity.Property(e => e.IdMotorista)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id_Motorista");
            entity.Property(e => e.NomeMotorista)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbPedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido);

            entity.ToTable("TB_PEDIDO");

            entity.Property(e => e.IdPedido)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id_Pedido");
            entity.Property(e => e.Data).HasColumnType("timestamp");
            entity.Property(e => e.DataFinalRecorrencia).HasColumnType("timestamp");
            entity.Property(e => e.DataInicioRecorrencia).HasColumnType("timestamp");
            entity.Property(e => e.IdCliente).HasColumnName("Id_Cliente");
            entity.Property(e => e.IdRota).HasColumnName("Id_Rota");
            entity.Property(e => e.Observacoes)
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.TbPedidos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_PEDIDO_TB_CLIENTE");

            entity.HasOne(d => d.IdRotaNavigation).WithMany(p => p.TbPedidos)
                .HasForeignKey(d => d.IdRota)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_PEDIDO_TB_ROTA");
        });

        modelBuilder.Entity<TbProduto>(entity =>
        {
            entity.HasKey(e => e.IdProduto);

            entity.ToTable("TB_Produtos");

            entity.Property(e => e.IdProduto)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id_Produto");
            entity.Property(e => e.NomeProduto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Unidade)
                .HasMaxLength(3)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbRotum>(entity =>
        {
            entity.HasKey(e => e.IdRota);

            entity.ToTable("TB_ROTA");

            entity.Property(e => e.IdRota)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id_Rota");
            entity.Property(e => e.IdMotorista).HasColumnName("Id_Motorista");
            entity.Property(e => e.Periodo)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdMotoristaNavigation).WithMany(p => p.TbRota)
                .HasForeignKey(d => d.IdMotorista)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TB_ROTA_TB_MOTORISTA");
        });

        modelBuilder.Entity<TbUsuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("TB_USUARIO");

            entity.Property(e => e.IdUsuario)
                .ValueGeneratedOnAdd()
                .HasColumnName("Id_Usuario");
            entity.Property(e => e.NomeUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Ativo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.SenhaUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
