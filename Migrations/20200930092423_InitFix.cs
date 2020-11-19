using Microsoft.EntityFrameworkCore.Migrations;

namespace InteractionService.Migrations
{
    public partial class InitFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ttl",
                table: "MessageRequests");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ttl",
                table: "MessageRequests",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
