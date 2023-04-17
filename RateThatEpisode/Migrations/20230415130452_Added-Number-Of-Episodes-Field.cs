using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RateThatEpisode.Migrations {
    /// <inheritdoc />
    public partial class AddedNumberOfEpisodesField : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfEpisodes",
                table: "Series",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropColumn(
                name: "NumberOfEpisodes",
                table: "Series");
        }
    }
}
