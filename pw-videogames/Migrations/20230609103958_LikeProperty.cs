using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pw_videogames.Migrations
{
    /// <inheritdoc />
    public partial class LikeProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Like",
                table: "Videogames",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Like",
                table: "Videogames");
        }
    }
}
