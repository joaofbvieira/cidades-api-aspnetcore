using Microsoft.EntityFrameworkCore.Migrations;

namespace Cidades.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    ibge_id = table.Column<int>(nullable: false),
                    uf = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    capital = table.Column<bool>(nullable: false),
                    lon = table.Column<decimal>(nullable: false),
                    lat = table.Column<decimal>(nullable: false),
                    no_accents = table.Column<string>(nullable: true),
                    alternative_names = table.Column<string>(nullable: true),
                    microregion = table.Column<string>(nullable: true),
                    mesoregion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.ibge_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cidades");
        }
    }
}
