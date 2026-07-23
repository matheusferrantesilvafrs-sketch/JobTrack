using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobTracker.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarModeloCadastro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descrições",
                table: "Cadastro",
                newName: "Status");

            migrationBuilder.AddColumn<string>(
                name: "Descricoes",
                table: "Cadastro",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Cadastro",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Plataforma",
                table: "Cadastro",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricoes",
                table: "Cadastro");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Cadastro");

            migrationBuilder.DropColumn(
                name: "Plataforma",
                table: "Cadastro");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Cadastro",
                newName: "Descrições");
        }
    }
}
