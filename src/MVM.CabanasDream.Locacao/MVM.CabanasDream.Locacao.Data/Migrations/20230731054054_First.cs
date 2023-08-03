using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVM.CabanasDream.Locacao.Data.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cbn_clientes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "varchar(255)", nullable: false),
                    data_nascimento = table.Column<DateTime>(type: "date", nullable: false),
                    tipo_documento = table.Column<int>(type: "int", nullable: false),
                    num_documento = table.Column<string>(type: "varchar(15)", nullable: false),
                    data_emissao = table.Column<DateTime>(type: "date", nullable: false),
                    email = table.Column<string>(type: "varchar(255)", nullable: false),
                    ddd_telefone = table.Column<string>(type: "varchar(2)", nullable: false),
                    telefone = table.Column<string>(type: "varchar(15)", nullable: false),
                    cep = table.Column<string>(type: "varchar(8)", nullable: false),
                    logradouro = table.Column<string>(type: "varchar(255)", nullable: false),
                    endereco_numero = table.Column<int>(type: "int", nullable: false),
                    bairro = table.Column<string>(type: "varchar(255)", nullable: false),
                    endereco_cidade = table.Column<string>(type: "varchar(255)", nullable: false),
                    endereco_uf = table.Column<string>(type: "varchar(2)", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cbn_clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cbn_temas",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "varchar(255)", nullable: false),
                    quantidade_estoque = table.Column<int>(type: "int", nullable: false),
                    disponibilidade = table.Column<bool>(type: "bool", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cbn_temas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cbn_contratos_locacoes",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    cliente_id = table.Column<Guid>(type: "uuid", nullable: false),
                    festa_id = table.Column<Guid>(type: "uuid", nullable: false),
                    data_devolucao = table.Column<DateTime>(type: "date", nullable: false),
                    valor_multa_contrato = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    valor_contrato = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    vigencia = table.Column<bool>(type: "bool", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cbn_contratos_locacoes", x => x.id);
                    table.ForeignKey(
                        name: "FK_cbn_contratos_locacoes_cbn_clientes_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "cbn_clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cbn_festas",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    tema_id = table.Column<Guid>(type: "uuid", nullable: false),
                    cliente_id = table.Column<Guid>(type: "uuid", nullable: false),
                    quantidade_participantes = table.Column<int>(type: "int", nullable: false),
                    status_festa = table.Column<int>(type: "int", nullable: false),
                    contrato_locacao_id = table.Column<Guid>(type: "uuid", nullable: false),
                    data_realizacao_festa = table.Column<DateTime>(type: "date", nullable: false),
                    data_criacao = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cbn_festas", x => x.id);
                    table.ForeignKey(
                        name: "FK_cbn_festas_cbn_clientes_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "cbn_clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cbn_festas_cbn_contratos_locacoes_contrato_locacao_id",
                        column: x => x.contrato_locacao_id,
                        principalTable: "cbn_contratos_locacoes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cbn_festas_cbn_temas_tema_id",
                        column: x => x.tema_id,
                        principalTable: "cbn_temas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cbn_items_festa",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    nome = table.Column<string>(type: "varchar(255)", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    TemaId = table.Column<Guid>(type: "uuid", nullable: true),
                    data_criacao = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cbn_items_festa", x => x.id);
                    table.ForeignKey(
                        name: "FK_cbn_items_festa_cbn_festas_id",
                        column: x => x.id,
                        principalTable: "cbn_festas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cbn_items_festa_cbn_temas_TemaId",
                        column: x => x.TemaId,
                        principalTable: "cbn_temas",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_cbn_contratos_locacoes_cliente_id",
                table: "cbn_contratos_locacoes",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_cbn_festas_cliente_id",
                table: "cbn_festas",
                column: "cliente_id");

            migrationBuilder.CreateIndex(
                name: "IX_cbn_festas_contrato_locacao_id",
                table: "cbn_festas",
                column: "contrato_locacao_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cbn_festas_tema_id",
                table: "cbn_festas",
                column: "tema_id");

            migrationBuilder.CreateIndex(
                name: "IX_cbn_items_festa_id",
                table: "cbn_items_festa",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_cbn_items_festa_TemaId",
                table: "cbn_items_festa",
                column: "TemaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cbn_items_festa");

            migrationBuilder.DropTable(
                name: "cbn_festas");

            migrationBuilder.DropTable(
                name: "cbn_contratos_locacoes");

            migrationBuilder.DropTable(
                name: "cbn_temas");

            migrationBuilder.DropTable(
                name: "cbn_clientes");
        }
    }
}
