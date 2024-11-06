using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace companyORM.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Dnumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marg_start_date = table.Column<int>(type: "int", nullable: false),
                    Marg_ssn = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Dnumber);
                });

            migrationBuilder.CreateTable(
                name: "Dept_Locationes",
                columns: table => new
                {
                    Dnumber = table.Column<int>(type: "int", nullable: false),
                    Dlocation = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dept_Locationes", x => new { x.Dnumber, x.Dlocation });
                    table.ForeignKey(
                        name: "FK_Dept_Locationes_Departments_Dnumber",
                        column: x => x.Dnumber,
                        principalTable: "Departments",
                        principalColumn: "Dnumber",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Employeese",
                columns: table => new
                {
                    SSN = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bdate = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sex = table.Column<bool>(type: "bit", nullable: false),
                    salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Dnumber = table.Column<int>(type: "int", nullable: false),
                    Super_ssn = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employeese", x => x.SSN);
                    table.ForeignKey(
                        name: "FK_Employeese_Departments_Dnumber",
                        column: x => x.Dnumber,
                        principalTable: "Departments",
                        principalColumn: "Dnumber",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Employeese_Employeese_Super_ssn",
                        column: x => x.Super_ssn,
                        principalTable: "Employeese",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Projectes",
                columns: table => new
                {
                    Pnumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dnumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projectes", x => x.Pnumber);
                    table.ForeignKey(
                        name: "FK_Projectes_Departments_Dnumber",
                        column: x => x.Dnumber,
                        principalTable: "Departments",
                        principalColumn: "Dnumber",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Dependentes",
                columns: table => new
                {
                    ESSN = table.Column<int>(type: "int", nullable: false),
                    Dependent_name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    sex = table.Column<bool>(type: "bit", nullable: false),
                    Bdate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependentes", x => new { x.ESSN, x.Dependent_name });
                    table.ForeignKey(
                        name: "FK_Dependentes_Employeese_ESSN",
                        column: x => x.ESSN,
                        principalTable: "Employeese",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Works_Ones",
                columns: table => new
                {
                    ESSN = table.Column<int>(type: "int", nullable: false),
                    Pnumber = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works_Ones", x => new { x.ESSN, x.Pnumber });
                    table.ForeignKey(
                        name: "FK_Works_Ones_Employeese_ESSN",
                        column: x => x.ESSN,
                        principalTable: "Employeese",
                        principalColumn: "SSN",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Works_Ones_Projectes_Pnumber",
                        column: x => x.Pnumber,
                        principalTable: "Projectes",
                        principalColumn: "Pnumber",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_Marg_ssn",
                table: "Departments",
                column: "Marg_ssn");

            migrationBuilder.CreateIndex(
                name: "IX_Employeese_Dnumber",
                table: "Employeese",
                column: "Dnumber");

            migrationBuilder.CreateIndex(
                name: "IX_Employeese_Super_ssn",
                table: "Employeese",
                column: "Super_ssn");

            migrationBuilder.CreateIndex(
                name: "IX_Projectes_Dnumber",
                table: "Projectes",
                column: "Dnumber");

            migrationBuilder.CreateIndex(
                name: "IX_Works_Ones_Pnumber",
                table: "Works_Ones",
                column: "Pnumber");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employeese_Marg_ssn",
                table: "Departments",
                column: "Marg_ssn",
                principalTable: "Employeese",
                principalColumn: "SSN",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employeese_Marg_ssn",
                table: "Departments");

            migrationBuilder.DropTable(
                name: "Dependentes");

            migrationBuilder.DropTable(
                name: "Dept_Locationes");

            migrationBuilder.DropTable(
                name: "Works_Ones");

            migrationBuilder.DropTable(
                name: "Projectes");

            migrationBuilder.DropTable(
                name: "Employeese");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
