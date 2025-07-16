using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspCRUD.Migrations
{
    /// <inheritdoc />
    public partial class InitialTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "varchar(100)", nullable: false),
                    EmployeeGender = table.Column<string>(type: "varchar(10)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    EmployeeDesignation = table.Column<string>(type: "varchar(200)", nullable: false),
                    Salary = table.Column<int>(type: "int", nullable: false),
                    EmployeeMarried = table.Column<string>(type: "varchar(10)", nullable: false),
                    EmployeeDescription = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
