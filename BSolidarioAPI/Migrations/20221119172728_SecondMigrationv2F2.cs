using Microsoft.EntityFrameworkCore.Migrations;

namespace BSolidarioAPI.Migrations
{
    public partial class SecondMigrationv2F2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ClientPlanTypes");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ClientPlanTypes");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "ClientPlanTypes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "ClientPlanTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlanTypeId",
                table: "ClientPlanTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "annual_interested",
                table: "ClientPlanTypes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "montly_interested",
                table: "ClientPlanTypes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "PlanType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientPlanTypes_ClientId",
                table: "ClientPlanTypes",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientPlanTypes_Clients_ClientId",
                table: "ClientPlanTypes",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientPlanTypes_Clients_ClientId",
                table: "ClientPlanTypes");

            migrationBuilder.DropTable(
                name: "PlanType");

            migrationBuilder.DropIndex(
                name: "IX_ClientPlanTypes_ClientId",
                table: "ClientPlanTypes");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "ClientPlanTypes");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "ClientPlanTypes");

            migrationBuilder.DropColumn(
                name: "PlanTypeId",
                table: "ClientPlanTypes");

            migrationBuilder.DropColumn(
                name: "annual_interested",
                table: "ClientPlanTypes");

            migrationBuilder.DropColumn(
                name: "montly_interested",
                table: "ClientPlanTypes");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ClientPlanTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ClientPlanTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
