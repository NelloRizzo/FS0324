using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace W9.D2.EFCRUD.Migrations
{
    /// <inheritdoc />
    public partial class InitManagement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FriendlyName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Text = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Text);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Body = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleTag",
                columns: table => new
                {
                    ArticlesId = table.Column<int>(type: "int", nullable: false),
                    TagsText = table.Column<string>(type: "nvarchar(12)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleTag", x => new { x.ArticlesId, x.TagsText });
                    table.ForeignKey(
                        name: "FK_ArticleTag_Articles_ArticlesId",
                        column: x => x.ArticlesId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleTag_Tag_TagsText",
                        column: x => x.TagsText,
                        principalTable: "Tag",
                        principalColumn: "Text",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Body = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comment_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Picture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true),
                    MimeType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    OriginalWidth = table.Column<int>(type: "int", nullable: false),
                    OriginalHeight = table.Column<int>(type: "int", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: true),
                    AuthorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Picture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Picture_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Picture_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CommentTag",
                columns: table => new
                {
                    CommentsId = table.Column<int>(type: "int", nullable: false),
                    TagsText = table.Column<string>(type: "nvarchar(12)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentTag", x => new { x.CommentsId, x.TagsText });
                    table.ForeignKey(
                        name: "FK_CommentTag_Comment_CommentsId",
                        column: x => x.CommentsId,
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentTag_Tag_TagsText",
                        column: x => x.TagsText,
                        principalTable: "Tag",
                        principalColumn: "Text",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PictureTag",
                columns: table => new
                {
                    PicturesId = table.Column<int>(type: "int", nullable: false),
                    TagsText = table.Column<string>(type: "nvarchar(12)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PictureTag", x => new { x.PicturesId, x.TagsText });
                    table.ForeignKey(
                        name: "FK_PictureTag_Picture_PicturesId",
                        column: x => x.PicturesId,
                        principalTable: "Picture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PictureTag_Tag_TagsText",
                        column: x => x.TagsText,
                        principalTable: "Tag",
                        principalColumn: "Text",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Email", "FriendlyName", "Password" },
                values: new object[,]
                {
                    { 1, "email1@test.com", "Friendly name 1", "password" },
                    { 2, "email2@test.com", "Friendly name 2", "password" },
                    { 3, "email3@test.com", "Friendly name 3", "password" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_AuthorId",
                table: "Articles",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleTag_TagsText",
                table: "ArticleTag",
                column: "TagsText");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_Email",
                table: "Authors",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ArticleId",
                table: "Comment",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_AuthorId",
                table: "Comment",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentTag_TagsText",
                table: "CommentTag",
                column: "TagsText");

            migrationBuilder.CreateIndex(
                name: "IX_Picture_ArticleId",
                table: "Picture",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Picture_AuthorId",
                table: "Picture",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_PictureTag_TagsText",
                table: "PictureTag",
                column: "TagsText");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleTag");

            migrationBuilder.DropTable(
                name: "CommentTag");

            migrationBuilder.DropTable(
                name: "PictureTag");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Picture");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
