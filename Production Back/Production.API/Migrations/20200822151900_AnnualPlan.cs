using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Production.API.Migrations
{
    public partial class AnnualPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    JMBG = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    DateOfEmployment = table.Column<DateTime>(nullable: false),
                    AccountNumber = table.Column<string>(nullable: true),
                    WorkplaceNumber = table.Column<int>(nullable: false),
                    OrganizationalUnitNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnnualProductionPlans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateOfIssue = table.Column<DateTime>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    WorkerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnualProductionPlans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnualProductionPlans_Workers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AnnualProductionPlanId = table.Column<int>(nullable: false),
                    Quantity = table.Column<double>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanItems_AnnualProductionPlans_AnnualProductionPlanId",
                        column: x => x.AnnualProductionPlanId,
                        principalTable: "AnnualProductionPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnnualProductionPlans_WorkerId",
                table: "AnnualProductionPlans",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanItems_AnnualProductionPlanId",
                table: "PlanItems",
                column: "AnnualProductionPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanItems_ProductId",
                table: "PlanItems",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlanItems");

            migrationBuilder.DropTable(
                name: "AnnualProductionPlans");

            migrationBuilder.DropTable(
                name: "Workers");
        }
    }
}
