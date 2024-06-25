using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMSWebAppLab2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cinemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinemaName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Cinemas$PrimaryKey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Duration = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)90),
                    Genre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false, defaultValue: 1914)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Movies$PrimaryKey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TookPartAs = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Persons$PrimaryKey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Halls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinemaId = table.Column<int>(type: "int", nullable: false),
                    HallName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MaxPlaces = table.Column<int>(type: "int", nullable: false, defaultValue: 30)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Halls$PrimaryKey", x => x.Id);
                    table.ForeignKey(
                        name: "Halls$CinemasHalls",
                        column: x => x.CinemaId,
                        principalTable: "Cinemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonsToMovies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PersonsToMovies$PrimaryKey", x => x.Id);
                    table.ForeignKey(
                        name: "PersonsToMovies$MoviesPersonsToMovies",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "PersonsToMovies$PersonsPersonsToMovies",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HallId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Sessions$PrimaryKey", x => x.Id);
                    table.ForeignKey(
                        name: "Sessions$HallsSessions",
                        column: x => x.HallId,
                        principalTable: "Halls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Sessions$MoviesSessions",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SessionId = table.Column<int>(type: "int", nullable: false),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    SoldTime = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Tickets$PrimaryKey", x => x.Id);
                    table.ForeignKey(
                        name: "Tickets$SessionsTickets",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "Cinemas$Address",
                table: "Cinemas",
                column: "Address",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Cinemas$CinemaName",
                table: "Cinemas",
                column: "CinemaName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Halls_CinemaId",
                table: "Halls",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "Movies$Title",
                table: "Movies",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Persons$MoviePersonId",
                table: "Persons",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Persons$PersonName",
                table: "Persons",
                column: "PersonName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PersonsToMovies$PersonToMovieMovieId",
                table: "PersonsToMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "PersonsToMovies$PersonToMoviePersonId",
                table: "PersonsToMovies",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "Sessions$SessionsHallId",
                table: "Sessions",
                column: "HallId");

            migrationBuilder.CreateIndex(
                name: "Sessions$SessionsMovieId",
                table: "Sessions",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "Tickets$Place",
                table: "Tickets",
                column: "SeatNumber");

            migrationBuilder.CreateIndex(
                name: "Tickets$TicketsSessionId",
                table: "Tickets",
                column: "SessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonsToMovies");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Halls");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Cinemas");
        }
    }
}
