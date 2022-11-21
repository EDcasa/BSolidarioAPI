using Microsoft.EntityFrameworkCore.Migrations;

namespace BSolidarioAPI.Migrations
{
    public partial class SecondMigrationv2F3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ClientPlanTypes_PlanTypeId",
                table: "ClientPlanTypes",
                column: "PlanTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientPlanTypes_PlanType_PlanTypeId",
                table: "ClientPlanTypes",
                column: "PlanTypeId",
                principalTable: "PlanType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientPlanTypes_PlanType_PlanTypeId",
                table: "ClientPlanTypes");

            migrationBuilder.DropIndex(
                name: "IX_ClientPlanTypes_PlanTypeId",
                table: "ClientPlanTypes");
        }
    }
}
