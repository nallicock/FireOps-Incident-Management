using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FireOps.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIncidentDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Incidents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Incidents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Incidents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Incidents");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Incidents");
        }
    }
}
