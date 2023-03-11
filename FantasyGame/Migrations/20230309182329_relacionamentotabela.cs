using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyGame.Migrations
{
    /// <inheritdoc />
    public partial class relacionamentotabela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campeonato");

            migrationBuilder.CreateTable(
                name: "Partida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Times = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: true),
                    Resultados = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: true),
                    IdTimeFutebol = table.Column<int>(type: "int", nullable: false),
                    TimeFutebolId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TimeFutebol_Partida",
                        column: x => x.TimeFutebolId,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Classificacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Campeao = table.Column<string>(type: "VARCHAR(350)", maxLength: 350, nullable: true),
                    Vice = table.Column<string>(type: "VARCHAR(350)", maxLength: 350, nullable: true),
                    Terceiro = table.Column<string>(type: "VARCHAR(350)", maxLength: 350, nullable: true),
                    PartidasId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classificacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classificacao_Partidas",
                        column: x => x.PartidasId,
                        principalTable: "Partida",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classificacao_PartidasId",
                table: "Classificacao",
                column: "PartidasId");

            migrationBuilder.CreateIndex(
                name: "IX_Partida_TimeFutebolId",
                table: "Partida",
                column: "TimeFutebolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classificacao");

            migrationBuilder.DropTable(
                name: "Partida");

            migrationBuilder.CreateTable(
                name: "Campeonato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTimeFutebol = table.Column<int>(type: "int", nullable: false),
                    Campeao = table.Column<string>(type: "VARCHAR(350)", maxLength: 350, nullable: true),
                    Jogo = table.Column<string>(type: "VARCHAR(350)", maxLength: 350, nullable: true),
                    Resultado = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    Terceiro = table.Column<string>(type: "VARCHAR(350)", maxLength: 350, nullable: true),
                    Vice = table.Column<string>(type: "VARCHAR(350)", maxLength: 350, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campeonato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campeonato_Time_IdTimeFutebol",
                        column: x => x.IdTimeFutebol,
                        principalTable: "Time",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campeonato_IdTimeFutebol",
                table: "Campeonato",
                column: "IdTimeFutebol",
                unique: true);
        }
    }
}
