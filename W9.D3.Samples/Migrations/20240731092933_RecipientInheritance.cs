using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W9.D3.Samples.Migrations
{
    /// <inheritdoc />
    public partial class RecipientInheritance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Recipient",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NationalCode",
                table: "Recipient",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Recipient",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "Recipient",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Recipient");

            migrationBuilder.DropColumn(
                name: "NationalCode",
                table: "Recipient");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Recipient");

            migrationBuilder.DropColumn(
                name: "type",
                table: "Recipient");
        }
    }
}
