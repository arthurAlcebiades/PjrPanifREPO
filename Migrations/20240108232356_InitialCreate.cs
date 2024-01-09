using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PrjPanifMVC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CLIENTE",
                columns: table => new
                {
                    Id_Cliente = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeCliente = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    CpfCnpj = table.Column<string>(type: "character varying(18)", unicode: false, maxLength: 18, nullable: false),
                    TelefoneContatoCliente = table.Column<string>(type: "character varying(20)", unicode: false, maxLength: 20, nullable: true),
                    EnderecoCliente = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    EnderecoBairro = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    EnderecoCidade = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    EnderecoCep = table.Column<long>(type: "bigint", nullable: false),
                    EnderecoUf = table.Column<string>(type: "character varying(2)", unicode: false, maxLength: 2, nullable: false),
                    EnderecoComplemento = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CLIENTE", x => x.Id_Cliente);
                });

            migrationBuilder.CreateTable(
                name: "TB_MOTORISTA",
                columns: table => new
                {
                    Id_Motorista = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeMotorista = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MOTORISTA", x => x.Id_Motorista);
                });

            migrationBuilder.CreateTable(
                name: "TB_Produtos",
                columns: table => new
                {
                    Id_Produto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeProduto = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    Unidade = table.Column<string>(type: "character varying(3)", unicode: false, maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Produtos", x => x.Id_Produto);
                });

            migrationBuilder.CreateTable(
                name: "TB_USUARIO",
                columns: table => new
                {
                    Id_Usuario = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeUsuario = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    SenhaUsuario = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false),
                    Ativo = table.Column<string>(type: "character(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIO", x => x.Id_Usuario);
                });

            migrationBuilder.CreateTable(
                name: "TB_ROTA",
                columns: table => new
                {
                    Id_Rota = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_Motorista = table.Column<int>(type: "integer", nullable: false),
                    Periodo = table.Column<string>(type: "character varying(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ROTA", x => x.Id_Rota);
                    table.ForeignKey(
                        name: "FK_TB_ROTA_TB_MOTORISTA",
                        column: x => x.Id_Motorista,
                        principalTable: "TB_MOTORISTA",
                        principalColumn: "Id_Motorista");
                });

            migrationBuilder.CreateTable(
                name: "TB_PEDIDO",
                columns: table => new
                {
                    Id_Pedido = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_Cliente = table.Column<int>(type: "integer", nullable: false),
                    Id_Rota = table.Column<int>(type: "integer", nullable: false),
                    Observacoes = table.Column<string>(type: "character varying(300)", unicode: false, maxLength: 300, nullable: true),
                    DataInicioRecorrencia = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DataFinalRecorrencia = table.Column<DateTime>(type: "timestamp", nullable: true),
                    Data = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PEDIDO", x => x.Id_Pedido);
                    table.ForeignKey(
                        name: "FK_TB_PEDIDO_TB_CLIENTE",
                        column: x => x.Id_Cliente,
                        principalTable: "TB_CLIENTE",
                        principalColumn: "Id_Cliente");
                    table.ForeignKey(
                        name: "FK_TB_PEDIDO_TB_ROTA",
                        column: x => x.Id_Rota,
                        principalTable: "TB_ROTA",
                        principalColumn: "Id_Rota");
                });

            migrationBuilder.CreateTable(
                name: "TB_ITEM_PEDIDO",
                columns: table => new
                {
                    Id_ItemPedido = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_Pedido = table.Column<int>(type: "integer", nullable: false),
                    Id_Produto = table.Column<int>(type: "integer", nullable: false),
                    Quantidade = table.Column<int>(type: "integer", nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    ValorDesconto = table.Column<decimal>(type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ITEM_PEDIDO", x => x.Id_ItemPedido);
                    table.ForeignKey(
                        name: "FK_TB_ITEM_PEDIDO_TB_PEDIDO",
                        column: x => x.Id_Pedido,
                        principalTable: "TB_PEDIDO",
                        principalColumn: "Id_Pedido",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_ITEM_PEDIDO_TB_Produtos",
                        column: x => x.Id_Produto,
                        principalTable: "TB_Produtos",
                        principalColumn: "Id_Produto");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_ITEM_PEDIDO_Id_Pedido",
                table: "TB_ITEM_PEDIDO",
                column: "Id_Pedido");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ITEM_PEDIDO_Id_Produto",
                table: "TB_ITEM_PEDIDO",
                column: "Id_Produto");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PEDIDO_Id_Cliente",
                table: "TB_PEDIDO",
                column: "Id_Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_TB_PEDIDO_Id_Rota",
                table: "TB_PEDIDO",
                column: "Id_Rota");

            migrationBuilder.CreateIndex(
                name: "IX_TB_ROTA_Id_Motorista",
                table: "TB_ROTA",
                column: "Id_Motorista");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_ITEM_PEDIDO");

            migrationBuilder.DropTable(
                name: "TB_USUARIO");

            migrationBuilder.DropTable(
                name: "TB_PEDIDO");

            migrationBuilder.DropTable(
                name: "TB_Produtos");

            migrationBuilder.DropTable(
                name: "TB_CLIENTE");

            migrationBuilder.DropTable(
                name: "TB_ROTA");

            migrationBuilder.DropTable(
                name: "TB_MOTORISTA");
        }
    }
}
