using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunOlympic1.Data.Migrations
{
    public partial class NewFieldsAddedInVideoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ThumbnailLink",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VideoLink",
                table: "Videos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThumbnailLink",
                table: "Videos");

            migrationBuilder.DropColumn(
                name: "VideoLink",
                table: "Videos");
        }
    }
}
