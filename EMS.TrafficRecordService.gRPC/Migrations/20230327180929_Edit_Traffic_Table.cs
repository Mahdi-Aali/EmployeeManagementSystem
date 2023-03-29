using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS.TrafficRecordService.gRPC.Migrations
{
    public partial class Edit_Traffic_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_Traffics",
                table: "Traffics",
                column: "TrafficDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Traffics",
                table: "Traffics");
        }
    }
}
