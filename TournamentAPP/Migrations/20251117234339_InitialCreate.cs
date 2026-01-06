using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentAPP.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rankings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tournament_Id = table.Column<int>(type: "int", nullable: false),
                    Player_Id = table.Column<int>(type: "int", nullable: false),
                    TotalPlayer_Points = table.Column<int>(type: "int", nullable: false),
                    Player_Position = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rankings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Round_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tournament_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTournament_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTournament_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Is_Online = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Round_Id = table.Column<int>(type: "int", nullable: false),
                    Tournament_Id = table.Column<int>(type: "int", nullable: false),
                    StartGame_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndGame_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Game_Local = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Game_State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameStreaming_Link = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Rounds_Round_Id",
                        column: x => x.Round_Id,
                        principalTable: "Rounds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Games_Tournaments_Tournament_Id",
                        column: x => x.Tournament_Id,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TournamentRounds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tournament_Id = table.Column<int>(type: "int", nullable: false),
                    Round_Id = table.Column<int>(type: "int", nullable: false),
                    TournamentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentRounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TournamentRounds_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Player_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Player_Age = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Player_DateOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Player_Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Player_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Player_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Users_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Player_Id = table.Column<int>(type: "int", nullable: false),
                    Enrollment_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Is_Approved = table.Column<bool>(type: "bit", nullable: false),
                    Tournament_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollments_Players_Player_Id",
                        column: x => x.Player_Id,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Tournaments_Tournament_Id",
                        column: x => x.Tournament_Id,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GamePlayerResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Game_Id = table.Column<int>(type: "int", nullable: false),
                    Player_Id = table.Column<int>(type: "int", nullable: false),
                    GamePlayer_Score = table.Column<int>(type: "int", nullable: false),
                    Is_Winner = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePlayerResults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GamePlayerResults_Games_Game_Id",
                        column: x => x.Game_Id,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePlayerResults_Players_Player_Id",
                        column: x => x.Player_Id,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerStatistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Player_Id = table.Column<int>(type: "int", nullable: false),
                    PlayerTotal_Games = table.Column<int>(type: "int", nullable: false),
                    PlayerTotal_Points = table.Column<int>(type: "int", nullable: false),
                    PlayerAvgPoints_PerGame = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlayerAvgWins_PerGame = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlayerTotal_Wins = table.Column<int>(type: "int", nullable: false),
                    PlayerTotal_Losses = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStatistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerStatistics_Players_Player_Id",
                        column: x => x.Player_Id,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_Player_Id",
                table: "Enrollments",
                column: "Player_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_Tournament_Id",
                table: "Enrollments",
                column: "Tournament_Id");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayerResults_Game_Id",
                table: "GamePlayerResults",
                column: "Game_Id");

            migrationBuilder.CreateIndex(
                name: "IX_GamePlayerResults_Player_Id",
                table: "GamePlayerResults",
                column: "Player_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Round_Id",
                table: "Games",
                column: "Round_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Games_Tournament_Id",
                table: "Games",
                column: "Tournament_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Players_User_Id",
                table: "Players",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStatistics_Player_Id",
                table: "PlayerStatistics",
                column: "Player_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TournamentRounds_TournamentId",
                table: "TournamentRounds",
                column: "TournamentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "GamePlayerResults");

            migrationBuilder.DropTable(
                name: "PlayerStatistics");

            migrationBuilder.DropTable(
                name: "Rankings");

            migrationBuilder.DropTable(
                name: "TournamentRounds");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
