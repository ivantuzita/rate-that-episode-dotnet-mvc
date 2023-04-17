using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RateThatEpisode.Migrations {
    /// <inheritdoc />
    public partial class updatedfieldsonbothtables : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.RenameColumn(
                name: "OverallRating",
                table: "Episodes",
                newName: "Rating");

            migrationBuilder.AddColumn<double>(
                name: "OverallRating",
                table: "Series",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropColumn(
                name: "OverallRating",
                table: "Series");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Episodes",
                newName: "OverallRating");
        }
    }
}
