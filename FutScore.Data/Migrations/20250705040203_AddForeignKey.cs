using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FutScore.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogadores_Times_TimeId",
                table: "Jogadores");

            migrationBuilder.DropForeignKey(
                name: "FK_Partidas_Campeonatos_CampeonatoId",
                table: "Partidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Times_Campeonatos_CampeonatoId",
                table: "Times");

            migrationBuilder.AlterColumn<int>(
                name: "CampeonatoId",
                table: "Times",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CampeonatoId",
                table: "Partidas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TimeId",
                table: "Jogadores",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogadores_Times_TimeId",
                table: "Jogadores",
                column: "TimeId",
                principalTable: "Times",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Partidas_Campeonatos_CampeonatoId",
                table: "Partidas",
                column: "CampeonatoId",
                principalTable: "Campeonatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Times_Campeonatos_CampeonatoId",
                table: "Times",
                column: "CampeonatoId",
                principalTable: "Campeonatos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogadores_Times_TimeId",
                table: "Jogadores");

            migrationBuilder.DropForeignKey(
                name: "FK_Partidas_Campeonatos_CampeonatoId",
                table: "Partidas");

            migrationBuilder.DropForeignKey(
                name: "FK_Times_Campeonatos_CampeonatoId",
                table: "Times");

            migrationBuilder.AlterColumn<int>(
                name: "CampeonatoId",
                table: "Times",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CampeonatoId",
                table: "Partidas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TimeId",
                table: "Jogadores",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogadores_Times_TimeId",
                table: "Jogadores",
                column: "TimeId",
                principalTable: "Times",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Partidas_Campeonatos_CampeonatoId",
                table: "Partidas",
                column: "CampeonatoId",
                principalTable: "Campeonatos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Times_Campeonatos_CampeonatoId",
                table: "Times",
                column: "CampeonatoId",
                principalTable: "Campeonatos",
                principalColumn: "Id");
        }
    }
}
