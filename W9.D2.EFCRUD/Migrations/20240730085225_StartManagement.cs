using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace W9.D2.EFCRUD.Migrations
{
    /// <inheritdoc />
    public partial class StartManagement : Migration
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
                    FriendlyName = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
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
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ArticleId = table.Column<int>(type: "int", nullable: true)
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { 1, "tommie@mayert.ca", "Madison Beahan", "password" },
                    { 2, "arnold@starkemmerich.info", "Prof. Zella Nolan", "password" },
                    { 3, "dax_predovic@tillman.us", "Gabe McGlynn", "password" },
                    { 4, "chyna@huels.name", "Mr. Rubye Willms", "password" },
                    { 5, "lance.dicki@schamberger.us", "Mr. Agustina Kreiger", "password" },
                    { 6, "jermaine.mclaughlin@kunde.name", "Rahul Wyman", "password" },
                    { 7, "olin@erdmanreichel.uk", "Katlyn Cummerata", "password" },
                    { 8, "bartholome@littlekautzer.us", "Eloisa Kirlin", "password" },
                    { 9, "joannie@kutch.uk", "Jarret Lynch", "password" },
                    { 10, "brendan@kuhlman.us", "Kari Bradtke", "password" },
                    { 11, "sabryna.rolfson@pfeffermonahan.co.uk", "Wellington Ratke", "password" },
                    { 12, "scot.haag@strosin.name", "Heath Kshlerin", "password" },
                    { 13, "colt_lynch@russel.ca", "Mr. Kamron Amara Turcotte", "password" },
                    { 14, "kurt@sauer.co.uk", "Lorenza Rempel", "password" },
                    { 15, "fredy@bodemcclure.us", "America Becker", "password" },
                    { 16, "caroline@oconnerfahey.ca", "Mr. Josiane Shanahan", "password" },
                    { 17, "marcelina_skiles@hegmann.name", "Luther Farrell", "password" },
                    { 18, "rudy@dubuqueshanahan.co.uk", "Ms. Alexandro Franz Towne MD", "password" },
                    { 19, "tierra.parker@cronin.info", "Cyrus Veum", "password" },
                    { 20, "kelsi@keeling.co.uk", "Cyril Schinner", "password" },
                    { 21, "gabriel.haley@quigleyhickle.uk", "Dr. Isaias Schinner DVM", "password" },
                    { 22, "morton_renner@voncartwright.ca", "Mrs. Cruz Cremin IV", "password" },
                    { 23, "francesca_schuster@daniel.co.uk", "Dr. Spencer Rath", "password" },
                    { 24, "sammy_funk@armstrong.com", "Ansel Braun", "password" },
                    { 25, "phoebe_lakin@reichel.name", "Prof. Pearline Volkman", "password" },
                    { 26, "orion@considineschamberger.biz", "Dr. Roma Keebler", "password" },
                    { 27, "alysson@daugherty.info", "Dr. Marta Emard I", "password" },
                    { 28, "jude.heidenreich@ruecker.name", "Scotty Ledner", "password" },
                    { 29, "leila.schmeler@mertz.com", "Mrs. Delta Schuyler Buckridge", "password" },
                    { 30, "jarrod.satterfield@schumm.info", "Griffin Bednar", "password" },
                    { 31, "helga_mcclure@bruen.biz", "Clementine Heaney", "password" },
                    { 32, "monique.anderson@rueckerhilll.ca", "Prof. Layla King", "password" },
                    { 33, "xavier@gislason.info", "Hilton Okuneva", "password" },
                    { 34, "gerard@kuhic.co.uk", "Stefanie Crona", "password" },
                    { 35, "johnathon@mcglynncrist.name", "Jerel Hoeger", "password" },
                    { 36, "layla@greenholtpadberg.ca", "Cara Darrick McDermott DVM", "password" },
                    { 37, "dalton.waters@rau.ca", "Jaquan Gaylord", "password" },
                    { 38, "candace@zboncak.com", "Emelie Wiegand", "password" },
                    { 39, "angeline_bradtke@carroll.uk", "Richie Herman", "password" },
                    { 40, "freeman@abernathyondricka.info", "Mrs. Ashton Konopelski", "password" },
                    { 41, "mertie.watsica@gibson.ca", "Euna Morar", "password" },
                    { 42, "reilly_legros@hane.uk", "Ms. Grayson Aiden Sawayn", "password" },
                    { 43, "trudie@pfannerstill.ca", "Jaren Frami", "password" },
                    { 44, "adelle_rogahn@klockomiller.biz", "Mr. Travon Nia Mann", "password" },
                    { 45, "rebecca@orn.us", "Dr. Cristina Senger", "password" },
                    { 46, "zelda.wisozk@hilll.us", "Samanta Fahey", "password" },
                    { 47, "rhiannon.rodriguez@cartwright.ca", "Mr. Tyrell Kirsten Hand", "password" },
                    { 48, "barney@stehr.biz", "Mrs. Else Feest MD", "password" },
                    { 49, "dario_skiles@towne.name", "Daphne Beahan MD", "password" },
                    { 50, "lyla_roob@dach.biz", "Coy Wintheiser", "password" },
                    { 51, "imogene@hauck.info", "Bret Crist", "password" },
                    { 52, "betty@considine.biz", "Jewel Rosenbaum", "password" },
                    { 53, "taylor@murray.us", "Mrs. Johanna Witting", "password" },
                    { 54, "devan@daugherty.co.uk", "Ms. Zackery Bergnaum Jr.", "password" },
                    { 55, "fanny@rueckerdavis.uk", "Carmella Halvorson", "password" },
                    { 56, "reid.feeney@gloverernser.us", "Mr. Anne Efrain Nolan", "password" },
                    { 57, "marilie@ward.biz", "Loraine Wintheiser", "password" },
                    { 58, "florida@marquardtarmstrong.biz", "Cassidy Hauck", "password" },
                    { 59, "rachael@simonis.co.uk", "Abigale Marques McLaughlin PhD", "password" },
                    { 60, "oleta@cassin.name", "Felipa Lehner", "password" },
                    { 61, "paxton@howe.com", "Mr. Sierra Goodwin", "password" },
                    { 62, "haskell.crist@moorestracke.info", "Mr. Bianka Jaylen Weber", "password" },
                    { 63, "margarete@langoshschulist.name", "Mr. Cleora Reta Murazik DVM", "password" },
                    { 64, "donnell@aufderhar.info", "Lamar Kling", "password" },
                    { 65, "dawn.bayer@rempel.ca", "Ms. Diana Jeramie Roberts", "password" },
                    { 66, "filomena.brown@wilderman.ca", "Mr. Ernesto Nakia Bernier", "password" },
                    { 67, "erling.weimann@king.us", "Mrs. Mabel Goldner", "password" },
                    { 68, "laurel_murray@hegmann.biz", "Mireya Pollich", "password" },
                    { 69, "zoila.gleason@leffler.uk", "Dr. Malcolm Lou Smith MD", "password" },
                    { 70, "urban@dietrichstroman.uk", "Sarah Ernser", "password" },
                    { 71, "skylar@haaghahn.ca", "Michale Hammes", "password" },
                    { 72, "mathilde@dickinson.ca", "Orin Zemlak", "password" },
                    { 73, "doyle@corwin.name", "Ms. Henri Jewess", "password" },
                    { 74, "brenden.pacocha@terry.name", "Viola Ettie Schuppe I", "password" },
                    { 75, "keshaun@hoeger.ca", "Noemi Gerda Windler III", "password" },
                    { 76, "alexa@nicolas.info", "Augusta Kihn", "password" },
                    { 77, "emmet@schmitt.com", "Ms. Justice Irwin Botsford", "password" },
                    { 78, "tressa.howell@gutmannabbott.info", "Hellen Renner", "password" },
                    { 79, "mason.rutherford@fahey.us", "Mr. Jacinthe Marvin V", "password" },
                    { 80, "guy_jaskolski@wisozk.info", "Noe Rice", "password" },
                    { 81, "madie_ortiz@green.biz", "Pauline Raynor", "password" },
                    { 82, "pedro.hansen@kunde.info", "Ms. Monserrat Franz Harris", "password" },
                    { 83, "elwin_okuneva@bashirian.name", "Prof. Pietro Langosh", "password" },
                    { 84, "christ@jakubowski.uk", "Fredrick Becker", "password" },
                    { 85, "marcel@eichmannzulauf.com", "Katrina Strosin", "password" },
                    { 86, "trinity_heidenreich@stoltenbergkoch.com", "Wava Parisian", "password" },
                    { 87, "kianna@schulistgoyette.ca", "Juston Brekke I", "password" },
                    { 88, "rosina@flatley.biz", "Cordia Kris", "password" },
                    { 89, "roxanne_brekke@donnellygoldner.com", "Zackary Leffler", "password" },
                    { 90, "nicola@brakus.info", "Sherwood Joel Moen DDS", "password" },
                    { 91, "michaela@johnstonmonahan.name", "Angelo Rath", "password" },
                    { 92, "elvie_mckenzie@schmeler.com", "Obie Powlowski I", "password" },
                    { 93, "patricia.cole@upton.biz", "Ms. Nolan Baumbach II", "password" },
                    { 94, "gregg@prosaccocasper.us", "Prof. Enoch Lenora Reynolds V", "password" },
                    { 95, "kelley@lockman.name", "Johann Hudson", "password" },
                    { 96, "sandra.cartwright@padbergkemmer.ca", "Ludwig McGlynn", "password" },
                    { 97, "vesta@kilbackking.us", "Dr. Ryan Dustin Tromp", "password" },
                    { 98, "jovani_mraz@bergstrom.biz", "Hermina Langworth", "password" },
                    { 99, "aiyana_vandervort@greenfelder.ca", "Antoinette Watsica", "password" },
                    { 100, "solon@hettinger.name", "Shyann Walker", "password" }
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
