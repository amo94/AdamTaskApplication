using Microsoft.EntityFrameworkCore.Migrations;

namespace AdamTaskApplication.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_files_FilesId",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_employees_FilesId",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "FilesId",
                table: "employees");

            migrationBuilder.AlterColumn<long>(
                name: "EmployeeID",
                table: "files",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "employees",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "employees",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "employees",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_files_EmployeeID",
                table: "files",
                column: "EmployeeID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_files_employees_EmployeeID",
                table: "files",
                column: "EmployeeID",
                principalTable: "employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_files_employees_EmployeeID",
                table: "files");

            migrationBuilder.DropIndex(
                name: "IX_files_EmployeeID",
                table: "files");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "files",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "employees",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "employees",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "employees",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AddColumn<long>(
                name: "FilesId",
                table: "employees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_employees_FilesId",
                table: "employees",
                column: "FilesId");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_files_FilesId",
                table: "employees",
                column: "FilesId",
                principalTable: "files",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
