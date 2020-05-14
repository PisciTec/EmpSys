using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpSys.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaID = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    cpf = table.Column<string>(nullable: true),
                    dateBirth = table.Column<DateTime>(nullable: false),
                    paycheck = table.Column<float>(nullable: false),
                    payment = table.Column<bool>(nullable: false),
                    Gender = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Employee_Area_AreaID",
                        column: x => x.AreaID,
                        principalTable: "Area",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dependent",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    cpf = table.Column<string>(nullable: true),
                    dateBirth = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependent", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Dependent_Employee_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dependent_EmployeeID",
                table: "Dependent",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AreaID",
                table: "Employee",
                column: "AreaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dependent");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Area");
        }
    }
}
