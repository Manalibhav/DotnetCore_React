using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DAirlines",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    airlinename = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    noofdesti = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    slogan = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    headquar = table.Column<string>(type: "nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DAirlines", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DAirlines");
        }
    }
}
