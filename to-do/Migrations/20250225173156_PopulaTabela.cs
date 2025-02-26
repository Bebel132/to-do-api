using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace to_do.Migrations
{
    /// <inheritdoc />
    public partial class PopulaTabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tarefas",
                columns: new[] { "Id", "Desc", "Status", "Titulo" },
                values: new object[,]
                {
                    { 1, "", true, "estudar" },
                    { 2, "tarefa aleatória n 10", true, "tarefa - ismd" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tarefas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tarefas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
