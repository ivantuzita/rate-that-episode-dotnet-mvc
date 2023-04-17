using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RateThatEpisode.Migrations {
    /// <inheritdoc />
    public partial class UpdateEpisodeTable : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.AddColumn<double>(
                name: "OverallRating",
                table: "Episodes",
                type: "double",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropColumn(
                name: "OverallRating",
                table: "Episodes");
        }
    }
}
