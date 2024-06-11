using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace thirdAssignment.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class changeLabTestAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LabtestAppointments_Appointments_AppointmentId",
                table: "LabtestAppointments");

            migrationBuilder.DropIndex(
                name: "IX_LabtestAppointments_AppointmentId",
                table: "LabtestAppointments");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "LabtestAppointments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AppointmentId",
                table: "LabtestAppointments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LabtestAppointments_AppointmentId",
                table: "LabtestAppointments",
                column: "AppointmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_LabtestAppointments_Appointments_AppointmentId",
                table: "LabtestAppointments",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id");
        }
    }
}
