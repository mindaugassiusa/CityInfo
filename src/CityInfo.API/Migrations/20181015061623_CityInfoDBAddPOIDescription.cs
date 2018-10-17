using Microsoft.EntityFrameworkCore.Migrations;

namespace CityInfo.API.Migrations
{
    public partial class CityInfoDBAddPOIDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Description",
                table: "PointsOfInterest",
                maxLength: 200,
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "PointsOfInterest");
        }
    }
}
