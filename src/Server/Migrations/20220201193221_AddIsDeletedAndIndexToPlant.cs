using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantsWatering.Server.Migrations
{
    public partial class AddIsDeletedAndIndexToPlant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Plants",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Plants_CommunicationChannelId",
                table: "Plants",
                column: "CommunicationChannelId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Plants_CommunicationChannelId",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Plants");
        }
    }
}
