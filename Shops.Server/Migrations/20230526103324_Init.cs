using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Shops.Server.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.UniqueConstraint("AK_Countries_Code", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    CountryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shops_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shops_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    ShopId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Managers_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Backstore = table.Column<long>(type: "bigint", nullable: false),
                    Frontstore = table.Column<long>(type: "bigint", nullable: false),
                    ShoppingWindow = table.Column<int>(type: "integer", nullable: false),
                    Accuracy = table.Column<float>(type: "real", nullable: false),
                    OnFloorAvailability = table.Column<float>(type: "real", nullable: false),
                    MeanAge = table.Column<int>(type: "integer", nullable: false),
                    ShopId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stocks_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                column: "Id",
                values: new object[]
                {
                    2,
                    3,
                    4,
                    5,
                    6,
                    7,
                    10
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Code" },
                values: new object[] { 1, "DE" });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "CategoryId", "CountryId", "Email", "Name" },
                values: new object[,]
                {
                    { 1, 10, 1, "Berlin@detego.com", "Berlin" },
                    { 2, 5, 1, "Hamburg@detego.com", "Hamburg" },
                    { 3, 6, 1, "München@detego.com", "München" },
                    { 4, 6, 1, "Köln@detego.com", "Köln" },
                    { 5, 7, 1, "Frankfurt@detego.com", "Frankfurt am Main" },
                    { 6, 5, 1, "Stuttgart@detego.com", "Stuttgart" },
                    { 7, 6, 1, "Düsseldorf@detego.com", "Düsseldorf" },
                    { 8, 5, 1, "Dortmund@detego.com", "Dortmund" },
                    { 9, 6, 1, "Essen@detego.com", "Essen" },
                    { 10, 3, 1, "Bremen@detego.com", "Bremen" },
                    { 11, 4, 1, "Leipzig@detego.com", "Leipzig" },
                    { 12, 7, 1, "Dresden@detego.com", "Dresden" },
                    { 13, 7, 1, "Hannover@detego.com", "Hannover" },
                    { 14, 5, 1, "Nürnberg@detego.com", "Nürnberg" },
                    { 15, 4, 1, "Duisburg@detego.com", "Duisburg" },
                    { 16, 5, 1, "Bochum@detego.com", "Bochum" },
                    { 17, 6, 1, "Wuppertal@detego.com", "Wuppertal" },
                    { 18, 4, 1, "Bielefeld@detego.com", "Bielefeld" },
                    { 19, 6, 1, "Bonn@detego.com", "Bonn" },
                    { 20, 6, 1, "Münster@detego.com", "Münster" },
                    { 21, 6, 1, "Karlsruhe@detego.com", "Karlsruhe" },
                    { 22, 3, 1, "Mannheim@detego.com", "Mannheim" },
                    { 23, 6, 1, "Augsburg@detego.com", "Augsburg" },
                    { 24, 4, 1, "Wiesbaden@detego.com", "Wiesbaden" },
                    { 25, 6, 1, "Gelsenkirchen@detego.com", "Gelsenkirchen" },
                    { 26, 3, 1, "Mönchengladbach@detego.com", "Mönchengladbach" },
                    { 27, 6, 1, "Braunschweig@detego.com", "Braunschweig" },
                    { 28, 4, 1, "Chemnitz@detego.com", "Chemnitz" },
                    { 29, 5, 1, "Aachen@detego.com", "Aachen" },
                    { 30, 4, 1, "Kiel@detego.com", "Kiel" },
                    { 31, 4, 1, "Halle@detego.com", "Halle (Saale)" },
                    { 32, 5, 1, "Magdeburg@detego.com", "Magdeburg" },
                    { 33, 5, 1, "Krefeld@detego.com", "Krefeld" },
                    { 34, 6, 1, "Freiburg@detego.com", "Freiburg im Breisgau" },
                    { 35, 6, 1, "Lübeck@detego.com", "Lübeck" },
                    { 36, 4, 1, "Oberhausen@detego.com", "Oberhausen" },
                    { 37, 4, 1, "Erfurt@detego.com", "Erfurt" },
                    { 38, 3, 1, "Mainz@detego.com", "Mainz" },
                    { 39, 5, 1, "Rostock@detego.com", "Rostock" },
                    { 40, 3, 1, "Kassel@detego.com", "Kassel" },
                    { 41, 5, 1, "Hagen@detego.com", "Hagen" },
                    { 42, 4, 1, "Saarbrücken@detego.com", "Saarbrücken" },
                    { 43, 6, 1, "Hamm@detego.com", "Hamm" },
                    { 44, 4, 1, "Mülheim@detego.com", "Mülheim an der Ruhr" },
                    { 45, 6, 1, "Ludwigshafen@detego.com", "Ludwigshafen am Rhein" },
                    { 46, 6, 1, "Potsdam@detego.com", "Potsdam" },
                    { 47, 6, 1, "Leverkusen@detego.com", "Leverkusen" },
                    { 48, 3, 1, "Oldenburg@detego.com", "Oldenburg" },
                    { 49, 6, 1, "Osnabrück@detego.com", "Osnabrück" },
                    { 50, 3, 1, "Solingen@detego.com", "Solingen" },
                    { 51, 3, 1, "Herne@detego.com", "Herne" },
                    { 52, 5, 1, "Neuss@detego.com", "Neuss" },
                    { 53, 4, 1, "Heidelberg@detego.com", "Heidelberg" },
                    { 54, 3, 1, "Darmstadt@detego.com", "Darmstadt" },
                    { 55, 5, 1, "Paderborn@detego.com", "Paderborn" },
                    { 56, 5, 1, "Regensburg@detego.com", "Regensburg" },
                    { 57, 2, 1, "Ingolstadt@detego.com", "Ingolstadt" },
                    { 58, 4, 1, "Würzburg@detego.com", "Würzburg" },
                    { 59, 4, 1, "Wolfsburg@detego.com", "Wolfsburg" },
                    { 60, 3, 1, "Fürth@detego.com", "Fürth" },
                    { 61, 6, 1, "Ulm@detego.com", "Ulm" },
                    { 62, 6, 1, "Offenbach@detego.com", "Offenbach am Main" },
                    { 63, 3, 1, "Heilbronn@detego.com", "Heilbronn" },
                    { 64, 4, 1, "Pforzheim@detego.com", "Pforzheim" },
                    { 65, 6, 1, "Göttingen@detego.com", "Göttingen" },
                    { 66, 6, 1, "Bottrop@detego.com", "Bottrop" },
                    { 67, 4, 1, "Recklinghausen@detego.com", "Recklinghausen" },
                    { 68, 2, 1, "Reutlingen@detego.com", "Reutlingen" },
                    { 69, 5, 1, "Koblenz@detego.com", "Koblenz" },
                    { 70, 2, 1, "BergischGladbach@detego.com", "Bergisch Gladbach" },
                    { 71, 4, 1, "Remscheid@detego.com", "Remscheid" },
                    { 72, 4, 1, "Bremerhaven@detego.com", "Bremerhaven" },
                    { 73, 3, 1, "Jena@detego.com", "Jena" },
                    { 74, 6, 1, "Trier@detego.com", "Trier" },
                    { 75, 5, 1, "Erlangen@detego.com", "Erlangen" },
                    { 76, 2, 1, "Moers@detego.com", "Moers" }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "ShopId" },
                values: new object[,]
                {
                    { 1, "femmot0@squidoo.com", "Freddie", "Emmot", 1 },
                    { 2, "kroth1@geocities.jp", "Kearney", "Roth", 2 },
                    { 3, "drisby2@wikimedia.org", "Drusy", "Risby", 3 },
                    { 4, "ptonsley3@engadget.com", "Penny", "Tonsley", 4 },
                    { 5, "agiuroni4@europa.eu", "Andy", "Giuroni", 5 },
                    { 6, "nfairham5@51.la", "Nolly", "Fairham", 6 },
                    { 7, "kdelany6@over-blog.com", "Kissie", "Delany", 7 },
                    { 8, "cdarby7@chron.com", "Chris", "Darby", 8 },
                    { 9, "gsurphliss8@mit.edu", "Gnni", "Surphliss", 9 },
                    { 10, "cvivian9@t.co", "Cory", "Vivian", 10 },
                    { 11, "rsienea@cbslocal.com", "Raquela", "Siene", 11 },
                    { 12, "mocannanb@livejournal.com", "Melitta", "O'Cannan", 12 },
                    { 13, "drossc@java.com", "Derrek", "Ross", 13 },
                    { 14, "vberardd@wordpress.com", "Vanya", "Berard", 14 },
                    { 15, "ahancorne@cyberchimps.com", "Ario", "Hancorn", 15 },
                    { 16, "tfranzenf@mayoclinic.com", "Trumaine", "Franzen", 16 },
                    { 17, "cnewingg@yahoo.com", "Chalmers", "Newing", 17 },
                    { 18, "ahardwellh@jugem.jp", "Arlen", "Hardwell", 18 },
                    { 19, "nwimmeri@springer.com", "Neile", "Wimmer", 19 },
                    { 20, "pcherrettj@amazon.de", "Pammi", "Cherrett", 20 },
                    { 21, "dlindenblattk@wired.com", "Dorolice", "Lindenblatt", 21 },
                    { 22, "koneilll@histats.com", "Klemens", "O'Neill", 22 },
                    { 23, "aokeeffem@forbes.com", "Abbey", "O'Keeffe", 23 },
                    { 24, "mmaccrawn@naver.com", "Marlowe", "Maccraw", 24 },
                    { 25, "spadillao@webeden.co.uk", "Siobhan", "Padilla", 25 },
                    { 26, "tmackeigp@eventbrite.com", "Tobi", "MacKeig", 26 },
                    { 27, "sbeldhamq@eventbrite.com", "Sonnie", "Beldham", 27 },
                    { 28, "apreatorr@techcrunch.com", "Alexis", "Preator", 28 },
                    { 29, "sedinboroughs@bloomberg.com", "Sondra", "Edinborough", 29 },
                    { 30, "mkillinert@naver.com", "Moses", "Killiner", 30 },
                    { 31, "aliffeyu@wix.com", "Andriette", "Liffey", 31 },
                    { 32, "nkenchv@mit.edu", "Nickola", "Kench", 32 },
                    { 33, "kpechtw@free.fr", "Kerby", "Pecht", 33 },
                    { 34, "pverricox@redcross.org", "Prinz", "Verrico", 34 },
                    { 35, "bferrey@unc.edu", "Byrom", "Ferre", 35 },
                    { 36, "tbuckleez@netlog.com", "Tracy", "Bucklee", 36 },
                    { 37, "bpapis10@wordpress.com", "Bryan", "Papis", 37 },
                    { 38, "lduffil11@mapquest.com", "Leonhard", "Duffil", 38 },
                    { 39, "amcilenna12@gnu.org", "Agnes", "McIlenna", 39 },
                    { 40, "pskerman13@t.co", "Prentice", "Skerman", 40 },
                    { 41, "amcbride14@uiuc.edu", "Amity", "McBride", 41 },
                    { 42, "gtrumper15@google.fr", "Georgie", "Trumper", 42 },
                    { 43, "odumbare16@gnu.org", "Orelee", "Dumbare", 43 },
                    { 44, "btroyes17@ebay.co.uk", "Berny", "Troyes", 44 },
                    { 45, "tchiverstone18@jiathis.com", "Tobias", "Chiverstone", 45 },
                    { 46, "wesposita19@ebay.com", "Wandis", "Esposita", 46 },
                    { 47, "rbau1a@printfriendly.com", "Rachel", "Bau", 47 },
                    { 48, "vkondratenya1b@blinklist.com", "Virgie", "Kondratenya", 48 },
                    { 49, "rmcdonough1c@oaic.gov.au", "Rhianna", "McDonough", 49 },
                    { 50, "mbingle1d@msn.com", "Mayer", "Bingle", 50 },
                    { 51, "aashment1e@usatoday.com", "Antonetta", "Ashment", 51 },
                    { 52, "twildblood1f@360.cn", "Tanhya", "Wildblood", 52 },
                    { 53, "dmcauley1g@aboutads.info", "Danella", "McAuley", 53 },
                    { 54, "gtchir1h@dion.ne.jp", "Grethel", "Tchir", 54 },
                    { 55, "amcevoy1i@wordpress.org", "Araldo", "McEvoy", 55 },
                    { 56, "bluckwell1j@engadget.com", "Belva", "Luckwell", 56 },
                    { 57, "chellyar1k@businesswire.com", "Carolina", "Hellyar", 57 },
                    { 58, "ebubbear1l@wordpress.org", "Eamon", "Bubbear", 58 },
                    { 59, "rdumbreck1m@indiegogo.com", "Rachel", "Dumbreck", 59 },
                    { 60, "jduncan1n@illinois.edu", "Jobyna", "Duncan", 60 },
                    { 61, "mravel1o@mtv.com", "Marney", "Ravel", 61 },
                    { 62, "amcshee1p@vimeo.com", "Allin", "McShee", 62 },
                    { 63, "okersaw1q@fastcompany.com", "Orelie", "Kersaw", 63 },
                    { 64, "maxelbey1r@ft.com", "Madison", "Axelbey", 64 },
                    { 65, "dbreckenridge1s@buzzfeed.com", "Darren", "Breckenridge", 65 },
                    { 66, "egosnoll1t@ihg.com", "Eldridge", "Gosnoll", 66 },
                    { 67, "rgratland1u@bigcartel.com", "Roderich", "Gratland", 67 },
                    { 68, "cfrederick1v@comcast.net", "Christoforo", "Frederick", 68 },
                    { 69, "hbeamand1w@alibaba.com", "Heath", "Beamand", 69 },
                    { 70, "astammirs1x@mysql.com", "Andros", "Stammirs", 70 },
                    { 71, "mrupert1y@purevolume.com", "Merola", "Rupert", 71 },
                    { 72, "ccracie1z@google.com.hk", "Caryn", "Cracie", 72 },
                    { 73, "gedinburgh20@comcast.net", "Georgina", "Edinburgh", 73 },
                    { 74, "skeveren21@vk.com", "Saunders", "Keveren", 74 },
                    { 75, "mscarman22@pbs.org", "Milissent", "Scarman", 75 },
                    { 76, "glethebridge23@wiley.com", "Giana", "Lethebridge", 76 }
                });

            migrationBuilder.InsertData(
                table: "Stocks",
                columns: new[] { "Id", "Accuracy", "Backstore", "Frontstore", "MeanAge", "OnFloorAvailability", "ShopId", "ShoppingWindow" },
                values: new object[,]
                {
                    { 1, 0.946f, 1514L, 5865L, 13, 0.888f, 1, 43 },
                    { 2, 0.806f, 863L, 2581L, 11, 0.999f, 2, 18 },
                    { 3, 0.987f, 1195L, 4309L, 7, 0.945f, 3, 9 },
                    { 4, 0.902f, 876L, 4259L, 10, 0.936f, 4, 12 },
                    { 5, 0.971f, 965L, 2815L, 8, 0.965f, 5, 7 },
                    { 6, 0.837f, 733L, 2089L, 5, 0.984f, 6, 21 },
                    { 7, 0.889f, 999L, 3065L, 8, 0.827f, 7, 16 },
                    { 8, 0.826f, 512L, 2378L, 5, 0.943f, 8, 20 },
                    { 9, 0.975f, 1041L, 3782L, 15, 0.917f, 9, 28 },
                    { 10, 0.817f, 319L, 1794L, 14, 0.808f, 10, 4 },
                    { 11, 0.975f, 537L, 2853L, 15, 0.962f, 11, 20 },
                    { 12, 0.894f, 732L, 4261L, 15, 0.999f, 12, 18 },
                    { 13, 0.902f, 753L, 3277L, 6, 0.848f, 13, 9 },
                    { 14, 0.979f, 825L, 3715L, 13, 0.835f, 14, 9 },
                    { 15, 0.922f, 682L, 2501L, 12, 0.899f, 15, 17 },
                    { 16, 0.949f, 954L, 3605L, 5, 0.872f, 16, 5 },
                    { 17, 0.804f, 910L, 3258L, 10, 0.958f, 17, 13 },
                    { 18, 0.987f, 776L, 2255L, 11, 0.896f, 18, 14 },
                    { 19, 0.946f, 1074L, 4358L, 6, 0.965f, 19, 25 },
                    { 20, 0.99f, 798L, 3223L, 9, 0.873f, 20, 9 },
                    { 21, 0.91f, 1011L, 3873L, 5, 0.882f, 21, 7 },
                    { 22, 0.899f, 555L, 2147L, 12, 0.815f, 22, 9 },
                    { 23, 0.844f, 602L, 3127L, 10, 0.801f, 23, 15 },
                    { 24, 0.824f, 561L, 2374L, 14, 0.814f, 24, 20 },
                    { 25, 0.95f, 990L, 4113L, 14, 0.891f, 25, 9 },
                    { 26, 0.837f, 391L, 2226L, 7, 0.973f, 26, 8 },
                    { 27, 0.951f, 729L, 3401L, 15, 0.865f, 27, 13 },
                    { 28, 0.825f, 493L, 3120L, 5, 0.922f, 28, 13 },
                    { 29, 0.885f, 568L, 2398L, 11, 0.861f, 29, 10 },
                    { 30, 0.856f, 436L, 1718L, 8, 0.879f, 30, 8 },
                    { 31, 0.981f, 559L, 3025L, 15, 0.96f, 31, 13 },
                    { 32, 0.942f, 809L, 2141L, 5, 0.983f, 32, 11 },
                    { 33, 0.806f, 683L, 3874L, 12, 0.843f, 33, 17 },
                    { 34, 0.981f, 1185L, 2417L, 5, 0.984f, 34, 19 },
                    { 35, 0.814f, 611L, 3292L, 8, 0.922f, 35, 8 },
                    { 36, 0.872f, 523L, 2646L, 8, 0.948f, 36, 12 },
                    { 37, 0.992f, 792L, 2086L, 7, 0.841f, 37, 10 },
                    { 38, 0.927f, 469L, 1729L, 9, 0.863f, 38, 3 },
                    { 39, 0.966f, 720L, 3228L, 12, 0.877f, 39, 16 },
                    { 40, 0.907f, 565L, 2315L, 8, 0.849f, 40, 13 },
                    { 41, 0.955f, 885L, 3354L, 12, 0.963f, 41, 6 },
                    { 42, 0.894f, 735L, 2443L, 11, 0.84f, 42, 16 },
                    { 43, 0.869f, 970L, 3174L, 12, 0.967f, 43, 18 },
                    { 44, 0.922f, 540L, 2840L, 6, 0.982f, 44, 10 },
                    { 45, 0.805f, 1105L, 3994L, 13, 0.951f, 45, 23 },
                    { 46, 0.933f, 643L, 3909L, 8, 0.983f, 46, 9 },
                    { 47, 0.987f, 987L, 4561L, 14, 0.999f, 47, 22 },
                    { 48, 0.838f, 405L, 2320L, 7, 0.916f, 48, 9 },
                    { 49, 0.857f, 767L, 4289L, 15, 0.805f, 49, 23 },
                    { 50, 0.958f, 329L, 1697L, 7, 0.982f, 50, 6 },
                    { 51, 0.928f, 552L, 2209L, 8, 0.819f, 51, 12 },
                    { 52, 0.978f, 535L, 3581L, 9, 0.881f, 52, 11 },
                    { 53, 0.939f, 796L, 2394L, 8, 0.804f, 53, 11 },
                    { 54, 0.886f, 314L, 2331L, 5, 0.808f, 54, 11 },
                    { 55, 0.896f, 978L, 3216L, 5, 0.942f, 55, 20 },
                    { 56, 0.807f, 942L, 2029L, 5, 0.86f, 56, 24 },
                    { 57, 0.898f, 220L, 1146L, 9, 0.821f, 57, 7 },
                    { 58, 0.895f, 603L, 3063L, 10, 0.92f, 58, 8 },
                    { 59, 0.82f, 670L, 1919L, 14, 0.929f, 59, 10 },
                    { 60, 0.905f, 313L, 1622L, 9, 0.982f, 60, 7 },
                    { 61, 0.907f, 1183L, 4766L, 6, 0.857f, 61, 21 },
                    { 62, 0.833f, 814L, 3391L, 12, 0.899f, 62, 23 },
                    { 63, 0.815f, 537L, 1311L, 6, 0.905f, 63, 13 },
                    { 64, 0.983f, 556L, 2102L, 12, 0.831f, 64, 19 },
                    { 65, 0.863f, 981L, 3820L, 12, 0.817f, 65, 27 },
                    { 66, 0.926f, 672L, 2775L, 8, 0.803f, 66, 21 },
                    { 67, 0.846f, 676L, 2384L, 10, 0.986f, 67, 6 },
                    { 68, 0.817f, 333L, 831L, 14, 0.895f, 68, 5 },
                    { 69, 0.855f, 875L, 3306L, 9, 0.814f, 69, 19 },
                    { 70, 0.85f, 296L, 1442L, 8, 0.969f, 70, 3 },
                    { 71, 0.966f, 400L, 3025L, 14, 0.929f, 71, 5 },
                    { 72, 0.839f, 712L, 2884L, 10, 0.866f, 72, 10 },
                    { 73, 0.874f, 540L, 2164L, 6, 0.829f, 73, 3 },
                    { 74, 0.841f, 892L, 3211L, 5, 0.869f, 74, 7 },
                    { 75, 0.96f, 567L, 2127L, 7, 0.915f, 75, 16 },
                    { 76, 0.85f, 253L, 1475L, 9, 0.957f, 76, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Managers_ShopId",
                table: "Managers",
                column: "ShopId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Shops_CategoryId",
                table: "Shops",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_CountryId",
                table: "Shops",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ShopId",
                table: "Stocks",
                column: "ShopId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "Stocks");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
