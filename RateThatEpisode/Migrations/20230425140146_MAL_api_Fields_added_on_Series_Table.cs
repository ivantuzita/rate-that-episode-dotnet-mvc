using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RateThatEpisode.Migrations
{
    /// <inheritdoc />
    public partial class MAL_api_Fields_added_on_Series_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MAL_Rating",
                table: "Series",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "MAL_url",
                table: "Series",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MAL_Rating",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "MAL_url",
                table: "Series");
        }
    }
}
