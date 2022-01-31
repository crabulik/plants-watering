using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantsWatering.Server.Migrations
{
    public partial class AddWateringSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WateringSchedule_Rate",
                table: "Plants",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WateringSchedule_Type",
                table: "Plants",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "WateringSchedule_WateringHour",
                table: "Plants",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WateringSchedule_WateringMinute",
                table: "Plants",
                type: "INTEGER",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WateringSchedule_Rate",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "WateringSchedule_Type",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "WateringSchedule_WateringHour",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "WateringSchedule_WateringMinute",
                table: "Plants");
        }
    }
}
