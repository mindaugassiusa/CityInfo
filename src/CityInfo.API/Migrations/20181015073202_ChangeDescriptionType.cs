using Microsoft.EntityFrameworkCore.Migrations;

namespace CityInfo.API.Migrations
{
    public partial class ChangeDescriptionType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "PointsOfInterest",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(int),
                oldMaxLength: 200);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Description",
                table: "PointsOfInterest",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}
