using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RateThatEpisode.Migrations {
    /// <inheritdoc />
    public partial class removeddebutyear : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropColumn(
                name: "DebutYear",
                table: "Series");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DebutYear",
                table: "Series",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}
