using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace CardsLibrary.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Alias = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tables_Games_GameID",
                        column: x => x.GameID,
                        principalTable: "Games",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoggedInUser",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoggedIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoggedInUser", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LoggedInUser_Users_UserID1",
                        column: x => x.UserID1,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TableID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TableID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Players_Tables_TableID1",
                        column: x => x.TableID1,
                        principalTable: "Tables",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Players_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Decks",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Column = table.Column<int>(type: "int", nullable: false),
                    HiddenCards = table.Column<int>(type: "int", nullable: false),
                    PlayerID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Row = table.Column<int>(type: "int", nullable: false),
                    TableID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TableID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Decks_Players_PlayerID1",
                        column: x => x.PlayerID1,
                        principalTable: "Players",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Decks_Tables_TableID1",
                        column: x => x.TableID1,
                        principalTable: "Tables",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Moves",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromCol = table.Column<int>(type: "int", nullable: false),
                    FromPlayerID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromPlayerID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FromRow = table.Column<int>(type: "int", nullable: false),
                    MoveIndex = table.Column<int>(type: "int", nullable: true),
                    TableID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TableID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ToCol = table.Column<int>(type: "int", nullable: false),
                    ToPlayerID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToPlayerID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ToRow = table.Column<int>(type: "int", nullable: false),
                    TypeOfMove = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Moves_Players_FromPlayerID1",
                        column: x => x.FromPlayerID1,
                        principalTable: "Players",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Moves_Tables_TableID1",
                        column: x => x.TableID1,
                        principalTable: "Tables",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Moves_Players_ToPlayerID1",
                        column: x => x.ToPlayerID1,
                        principalTable: "Players",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CardIndex = table.Column<int>(type: "int", nullable: true),
                    DeckID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeckID1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cards_Decks_DeckID1",
                        column: x => x.DeckID1,
                        principalTable: "Decks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_DeckID1",
                table: "Cards",
                column: "DeckID1");

            migrationBuilder.CreateIndex(
                name: "IX_Decks_PlayerID1",
                table: "Decks",
                column: "PlayerID1");

            migrationBuilder.CreateIndex(
                name: "IX_Decks_TableID1",
                table: "Decks",
                column: "TableID1");

            migrationBuilder.CreateIndex(
                name: "IX_LoggedInUser_UserID1",
                table: "LoggedInUser",
                column: "UserID1");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_FromPlayerID1",
                table: "Moves",
                column: "FromPlayerID1");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_TableID1",
                table: "Moves",
                column: "TableID1");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_ToPlayerID1",
                table: "Moves",
                column: "ToPlayerID1");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TableID1",
                table: "Players",
                column: "TableID1");

            migrationBuilder.CreateIndex(
                name: "IX_Players_UserID",
                table: "Players",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_GameID",
                table: "Tables",
                column: "GameID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "LoggedInUser");

            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropTable(
                name: "Decks");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
