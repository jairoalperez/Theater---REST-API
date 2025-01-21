using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Actors_RestAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SkinColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EyeColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HairColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrontImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullBodyImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.ActorId);
                });

            migrationBuilder.CreateTable(
                name: "Plays",
                columns: table => new
                {
                    PlayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Format = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferenceId = table.Column<int>(type: "int", nullable: true),
                    Poster = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScriptLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plays", x => x.PlayId);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActorId = table.Column<int>(type: "int", nullable: true),
                    PlayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterId);
                    table.ForeignKey(
                        name: "FK_Characters_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "ActorId");
                    table.ForeignKey(
                        name: "FK_Characters_Plays_PlayId",
                        column: x => x.PlayId,
                        principalTable: "Plays",
                        principalColumn: "PlayId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Musics",
                columns: table => new
                {
                    MusicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Artist = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MusicLink = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musics", x => x.MusicId);
                    table.ForeignKey(
                        name: "FK_Musics_Plays_PlayId",
                        column: x => x.PlayId,
                        principalTable: "Plays",
                        principalColumn: "PlayId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "References",
                columns: table => new
                {
                    ReferenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_References", x => x.ReferenceId);
                    table.ForeignKey(
                        name: "FK_References_Plays_PlayId",
                        column: x => x.PlayId,
                        principalTable: "Plays",
                        principalColumn: "PlayId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ActorId",
                table: "Characters",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_PlayId",
                table: "Characters",
                column: "PlayId");

            migrationBuilder.CreateIndex(
                name: "IX_Musics_PlayId",
                table: "Musics",
                column: "PlayId");

            migrationBuilder.CreateIndex(
                name: "IX_References_PlayId",
                table: "References",
                column: "PlayId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Musics");

            migrationBuilder.DropTable(
                name: "References");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Plays");
        }
    }
}
