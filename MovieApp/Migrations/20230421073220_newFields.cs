using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApp.Migrations
{
    /// <inheritdoc />
    public partial class newFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Plot",
                table: "Movie",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Poster",
                table: "Movie",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Plot",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Poster",
                table: "Movie");
        }
    }
}
