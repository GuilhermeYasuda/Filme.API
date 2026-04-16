using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmeApi.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "app");

            migrationBuilder.CreateTable(
                name: "Filmes",
                schema: "app",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Titulo = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Genero = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DtLancamento = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Avaliacao = table.Column<double>(type: "double precision", nullable: false),
                    DtCriacao = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    DtUltimaAlteracao = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filmes_Titulo", 
                schema: "app",
                table: "Filmes",
                column: "Titulo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filmes",
                schema: "app");
        }
    }
}
