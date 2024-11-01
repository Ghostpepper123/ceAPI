using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataModel.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    iso2 = table.Column<string>(type: "char(2)", unicode: false, fixedLength: true, maxLength: 2, nullable: false),
                    iso3 = table.Column<string>(type: "nchar(3)", fixedLength: true, maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    lat = table.Column<double>(type: "float", nullable: false),
                    lng = table.Column<double>(type: "float", nullable: false),
                    population = table.Column<int>(type: "int", nullable: false),
                    countryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_Cities_Countries1",
                        column: x => x.countryID,
                        principalTable: "Countries",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_countryID",
                table: "Cities",
                column: "countryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
