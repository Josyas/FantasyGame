using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FantasyGame.Migrations
{
    /// <inheritdoc />
    public partial class inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Time",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTime = table.Column<string>(type: "VARCHAR(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Time", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campeonato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jogo = table.Column<string>(type: "VARCHAR(350)", maxLength: 350, nullable: true),
                    Resultado = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    Campeao = table.Column<string>(type: "VARCHAR(350)", maxLength: 350, nullable: true),
                    Vice = table.Column<string>(type: "VARCHAR(350)", maxLength: 350, nullable: true),
                    Terceiro = table.Column<string>(type: "VARCHAR(350)", maxLength: 350, nullable: true),
                    IdTimeFutebol = table.Column<int>(type: "int", nullable: false)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campeonato");

            migrationBuilder.DropTable(
                name: "Time");
        }
    }
}
