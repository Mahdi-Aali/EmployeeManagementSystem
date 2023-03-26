using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.PersonalInformation.gRPC.Migrations
{
    public partial class EditPersonalInformationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "PersonalInformations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "PersonalInformations");
        }
    }
}
