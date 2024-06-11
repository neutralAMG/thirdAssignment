using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace thirdAssignment.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updategb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_ConsultingRooms_ConsultingRoomId1",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_ConsultingRoomId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_ConsultingRooms_Id",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_ConsultingRoomId1",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ConsultingRoomId1",
                table: "Appointments");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_ConsultingRoomId",
                table: "Doctors",
                column: "ConsultingRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_ConsultingRooms_ConsultingRoomId",
                table: "Appointments",
                column: "ConsultingRoomId",
                principalTable: "ConsultingRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_ConsultingRooms_ConsultingRoomId",
                table: "Doctors",
                column: "ConsultingRoomId",
                principalTable: "ConsultingRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_ConsultingRooms_ConsultingRoomId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_ConsultingRooms_ConsultingRoomId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_ConsultingRoomId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments");

            migrationBuilder.AddColumn<Guid>(
                name: "ConsultingRoomId1",
                table: "Appointments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ConsultingRoomId1",
                table: "Appointments",
                column: "ConsultingRoomId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_ConsultingRooms_ConsultingRoomId1",
                table: "Appointments",
                column: "ConsultingRoomId1",
                principalTable: "ConsultingRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_ConsultingRoomId",
                table: "Appointments",
                column: "ConsultingRoomId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_ConsultingRooms_Id",
                table: "Doctors",
                column: "Id",
                principalTable: "ConsultingRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
