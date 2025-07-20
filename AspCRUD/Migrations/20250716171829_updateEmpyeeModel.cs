using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspCRUD.Migrations
{
    /// <inheritdoc />
    public partial class updateEmpyeeModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeDescription",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "EmployeeMarried",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "Salary",
                table: "Employees",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "EmployeeDesignation",
                table: "Employees",
                newName: "EmployeeEmail");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Employees",
                newName: "Salary");

            migrationBuilder.RenameColumn(
                name: "EmployeeEmail",
                table: "Employees",
                newName: "EmployeeDesignation");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeDescription",
                table: "Employees",
                type: "varchar(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeMarried",
                table: "Employees",
                type: "varchar(10)",
                nullable: false,
                defaultValue: "");
        }
    }
}
