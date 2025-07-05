using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FutScore.Data.Migrations
{
    /// <inheritdoc />
    public partial class PopulandoBancoDeDados : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Times",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Jogadores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Campeonatos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Cariocão" });

            migrationBuilder.InsertData(
                table: "Times",
                columns: new[] { "Id", "CampeonatoId", "Forca", "GolsContra", "GolsPro", "Nome", "Pontuacao", "SaldoDeGols" },
                values: new object[,]
                {
                    { 1, 1, 60, 0, 0, "Vasco", 0, 0 },
                    { 2, 1, 70, 0, 0, "Flamengo", 0, 0 },
                    { 3, 1, 65, 0, 0, "Botafogo", 0, 0 },
                    { 4, 1, 68, 0, 0, "Fluminense", 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Jogadores",
                columns: new[] { "Id", "Gols", "Nome", "Posicao", "TimeId" },
                values: new object[,]
                {
                    { 1, 0, "Paulinho", 3, 1 },
                    { 2, 0, "Coutinho", 4, 1 },
                    { 3, 0, "Vegetti", 6, 1 },
                    { 4, 0, "Léo Jardim", 0, 1 },
                    { 5, 0, "João Victor", 1, 1 },
                    { 6, 0, "Nuno", 5, 1 },
                    { 7, 0, "David", 5, 1 },
                    { 8, 0, "Sforza", 3, 1 },
                    { 9, 0, "Lucas Freitas", 1, 1 },
                    { 10, 0, "Lucas Piton", 2, 1 },
                    { 11, 0, "Paulo Henrique", 2, 1 },
                    { 12, 0, "Arrascaeta", 4, 2 },
                    { 13, 0, "Pedro", 6, 2 },
                    { 14, 0, "Pulgar", 3, 2 },
                    { 15, 0, "Cebolinha", 5, 2 },
                    { 16, 0, "Nico De La Cruz", 5, 2 },
                    { 17, 0, "Léo Ortiz", 1, 2 },
                    { 18, 0, "Léo Pereira", 1, 2 },
                    { 19, 0, "Gerson", 4, 2 },
                    { 20, 0, "Wesley", 2, 2 },
                    { 21, 0, "Ayrton Lucas", 2, 2 },
                    { 22, 0, "Rossi", 0, 2 },
                    { 23, 0, "John", 0, 3 },
                    { 24, 0, "Damián Suárez", 2, 3 },
                    { 25, 0, "Bastos", 1, 3 },
                    { 26, 0, "Lucas Halter", 1, 3 },
                    { 27, 0, "Cuiabano", 2, 3 },
                    { 28, 0, "Marlon Freitas", 3, 3 },
                    { 29, 0, "Danilo Barbosa", 3, 3 },
                    { 30, 0, "Luiz Henrique", 5, 3 },
                    { 31, 0, "Júnior Santos", 5, 3 },
                    { 32, 0, "Tiquinho Soares", 6, 3 },
                    { 33, 0, "Eduardo", 4, 3 },
                    { 34, 0, "Fábio", 0, 4 },
                    { 35, 0, "Samuel Xavier", 2, 4 },
                    { 36, 0, "Felipe Melo", 1, 4 },
                    { 37, 0, "Marlon", 1, 4 },
                    { 38, 0, "Marcelo", 2, 4 },
                    { 39, 0, "André", 3, 4 },
                    { 40, 0, "Martinelli", 3, 4 },
                    { 41, 0, "Ganso", 4, 4 },
                    { 42, 0, "Jhon Arias", 4, 4 },
                    { 43, 0, "Keno", 5, 4 },
                    { 44, 0, "Germán Cano", 6, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Jogadores",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Times",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Campeonatos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Times");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Jogadores");
        }
    }
}
