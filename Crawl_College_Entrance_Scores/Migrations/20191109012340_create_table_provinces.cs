using Microsoft.EntityFrameworkCore.Migrations;

namespace Crawl_College_Entrance_Scores.Migrations
{
    public partial class create_table_provinces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
            name: "provinces",
            schema: "Entrance_Scores",
            columns: table => new
            {
                province_code = table.Column<int>(nullable:false),
                name = table.Column<string>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_collegeEntities", x => x.province_code);
                
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "provinces");
        }
    }
}
