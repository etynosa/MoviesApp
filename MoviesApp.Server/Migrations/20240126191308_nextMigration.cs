using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class nextMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseYear",
                table: "Movies");

            migrationBuilder.AddColumn<float>(
                name: "TicketPrice",
                table: "Movies",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketPrice",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "ReleaseYear",
                table: "Movies",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
