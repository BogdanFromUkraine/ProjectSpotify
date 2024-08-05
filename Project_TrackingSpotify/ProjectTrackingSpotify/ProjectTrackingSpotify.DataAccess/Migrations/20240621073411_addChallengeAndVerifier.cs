using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTrackingSpotify.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addChallengeAndVerifier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Challenge",
                table: "UrlSpotify",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Verifier",
                table: "UrlSpotify",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Challenge",
                table: "UrlSpotify");

            migrationBuilder.DropColumn(
                name: "Verifier",
                table: "UrlSpotify");
        }
    }
}
