using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace thirdAssignment.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changeLabTestAppointment2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabtestAppointments_LabTests_LabTestId",
                table: "LabtestAppointments");

            migrationBuilder.DropIndex(
                name: "IX_LabtestAppointments_LabTestId",
                table: "LabtestAppointments");

            migrationBuilder.DropColumn(
                name: "LabTestId",
                table: "LabtestAppointments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LabTestId",
                table: "LabtestAppointments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LabtestAppointments_LabTestId",
                table: "LabtestAppointments",
                column: "LabTestId");

            migrationBuilder.AddForeignKey(
                name: "FK_LabtestAppointments_LabTests_LabTestId",
                table: "LabtestAppointments",
                column: "LabTestId",
                principalTable: "LabTests",
                principalColumn: "Id");
        }
    }
}
