﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace thirdAssignment.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateBD : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppointmentStates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentStates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsultingRooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultingRooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRols",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRols", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsultingRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "Fk_For_doctors_ConsultingRoomId",
                        column: x => x.ConsultingRoomId,
                        principalTable: "ConsultingRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LabTests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsultingRoomId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsultingRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabTests_ConsultingRooms_ConsultingRoomId1",
                        column: x => x.ConsultingRoomId1,
                        principalTable: "ConsultingRooms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Fk_For_labTest_ConsultingRoomId",
                        column: x => x.ConsultingRoomId,
                        principalTable: "ConsultingRooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSmoker = table.Column<bool>(type: "bit", nullable: false),
                    HasAllergies = table.Column<bool>(type: "bit", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConsultingRoomId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsultingRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patients_ConsultingRooms_ConsultingRoomId1",
                        column: x => x.ConsultingRoomId1,
                        principalTable: "ConsultingRooms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Fk_For_patients_ConsultingRoomId",
                        column: x => x.ConsultingRoomId,
                        principalTable: "ConsultingRooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsultingRoomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    UserRolId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsultingRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EMailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserRols_RolId",
                        column: x => x.RolId,
                        principalTable: "UserRols",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_UserRols_UserRolId",
                        column: x => x.UserRolId,
                        principalTable: "UserRols",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "Fk_For_user_ConsultingRoomId",
                        column: x => x.ConsultingRoomId,
                        principalTable: "ConsultingRooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AppointmentTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    AppointmentCause = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppointmentStateId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PatientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsultingRoomId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DoctorId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsultingRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_AppointmentStates_AppointmentStateId",
                        column: x => x.AppointmentStateId,
                        principalTable: "AppointmentStates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointments_ConsultingRooms_ConsultingRoomId1",
                        column: x => x.ConsultingRoomId1,
                        principalTable: "ConsultingRooms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId1",
                        column: x => x.DoctorId1,
                        principalTable: "Doctors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_For_appointments_ConsultingRoomId",
                        column: x => x.ConsultingRoomId,
                        principalTable: "ConsultingRooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LabtestAppointments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LabTesttId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsNotPending = table.Column<bool>(type: "bit", nullable: false),
                    TestResult = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ConsultingRoomId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsultingRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabtestAppointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LabtestAppointments_Appointments_AppointmetId",
                        column: x => x.AppointmetId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabtestAppointments_ConsultingRooms_ConsultingRoomId",
                        column: x => x.ConsultingRoomId,
                        principalTable: "ConsultingRooms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LabtestAppointments_ConsultingRooms_ConsultingRoomId1",
                        column: x => x.ConsultingRoomId1,
                        principalTable: "ConsultingRooms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LabtestAppointments_LabTests_LabTesttId",
                        column: x => x.LabTesttId,
                        principalTable: "LabTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppointmentStates",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pending consultation" },
                    { 2, "Pending results" },
                    { 3, "Completed" }
                });

            migrationBuilder.InsertData(
                table: "UserRols",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Assistent" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointmentStateId",
                table: "Appointments",
                column: "AppointmentStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ConsultingRoomId",
                table: "Appointments",
                column: "ConsultingRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ConsultingRoomId1",
                table: "Appointments",
                column: "ConsultingRoomId1");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId1",
                table: "Appointments",
                column: "DoctorId1");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_ConsultingRoomId",
                table: "Doctors",
                column: "ConsultingRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_LabtestAppointments_AppointmetId",
                table: "LabtestAppointments",
                column: "AppointmetId");

            migrationBuilder.CreateIndex(
                name: "IX_LabtestAppointments_ConsultingRoomId",
                table: "LabtestAppointments",
                column: "ConsultingRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_LabtestAppointments_ConsultingRoomId1",
                table: "LabtestAppointments",
                column: "ConsultingRoomId1");

            migrationBuilder.CreateIndex(
                name: "IX_LabtestAppointments_LabTesttId",
                table: "LabtestAppointments",
                column: "LabTesttId");

            migrationBuilder.CreateIndex(
                name: "IX_LabTests_ConsultingRoomId",
                table: "LabTests",
                column: "ConsultingRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_LabTests_ConsultingRoomId1",
                table: "LabTests",
                column: "ConsultingRoomId1");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ConsultingRoomId",
                table: "Patients",
                column: "ConsultingRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_ConsultingRoomId1",
                table: "Patients",
                column: "ConsultingRoomId1");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ConsultingRoomId",
                table: "Users",
                column: "ConsultingRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolId",
                table: "Users",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRolId",
                table: "Users",
                column: "UserRolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabtestAppointments");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "LabTests");

            migrationBuilder.DropTable(
                name: "UserRols");

            migrationBuilder.DropTable(
                name: "AppointmentStates");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "ConsultingRooms");
        }
    }
}
