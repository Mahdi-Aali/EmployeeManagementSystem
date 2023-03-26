using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.PersonalInformation.gRPC.Migrations
{
    public partial class Edit_PersonalInformation_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "PersonalInformations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "PersonalInformations",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "PersonalInformations");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "PersonalInformations");
        }
    }
}
