using Microsoft.EntityFrameworkCore.Migrations;

namespace EasyTalents.Infra.Migrations
{
    public partial class Candidate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CrudRating",
                table: "Candidate",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CrudRating",
                table: "Candidate");
        }
    }
}
