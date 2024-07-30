using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W9.D2.EFCRUD.Migrations
{
    /// <inheritdoc />
    public partial class AddedAuthorOnComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Authors_AuthorId",
                table: "Comment");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Authors_AuthorId",
                table: "Comment",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Authors_AuthorId",
                table: "Comment");

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Comment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Authors_AuthorId",
                table: "Comment",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id");
        }
    }
}
