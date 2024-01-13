using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Clocking_LastClockingId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_LastClockingId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "LastClockingId",
                table: "Employees",
                newName: "ClockingId");

            migrationBuilder.CreateIndex(
                name: "IX_Clocking_EmployeeId",
                table: "Clocking",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clocking_Employees_EmployeeId",
                table: "Clocking",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clocking_Employees_EmployeeId",
                table: "Clocking");

            migrationBuilder.DropIndex(
                name: "IX_Clocking_EmployeeId",
                table: "Clocking");

            migrationBuilder.RenameColumn(
                name: "ClockingId",
                table: "Employees",
                newName: "LastClockingId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_LastClockingId",
                table: "Employees",
                column: "LastClockingId",
                unique: true,
                filter: "[LastClockingId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Clocking_LastClockingId",
                table: "Employees",
                column: "LastClockingId",
                principalTable: "Clocking",
                principalColumn: "Id");
        }
    }
}
