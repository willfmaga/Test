using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Teste.Infra.CrossCutting.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfiguracaoJob",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    IntervaloExecucaoTipoId = table.Column<int>(nullable: false),
                    IntervaloExecucao = table.Column<int>(nullable: true),
                    StatusId = table.Column<int>(nullable: false),
                    DataInclusao = table.Column<DateTime>(nullable: true),
                    DataAtualizacao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguracaoJob", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfiguracaoJobAgendamento",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfiguracaoJobId = table.Column<int>(nullable: false),
                    HorarioAgendamento = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguracaoJobAgendamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfiguracaoJobAgendamento_ConfiguracaoJob_ConfiguracaoJobId",
                        column: x => x.ConfiguracaoJobId,
                        principalTable: "ConfiguracaoJob",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguracaoJobAgendamento_ConfiguracaoJobId",
                table: "ConfiguracaoJobAgendamento",
                column: "ConfiguracaoJobId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfiguracaoJobAgendamento");

            migrationBuilder.DropTable(
                name: "ConfiguracaoJob");
        }
    }
}
