using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedLinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineTool_MachineToolType_MachineToolTypeId",
                table: "MachineTool");

            migrationBuilder.DropForeignKey(
                name: "FK_Sensor_MachineTool_MachineToolId",
                table: "Sensor");

            migrationBuilder.DropForeignKey(
                name: "FK_Sensor_MeasureType_MeasureTypeId",
                table: "Sensor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MeasureType",
                table: "MeasureType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MachineToolType",
                table: "MachineToolType");

            migrationBuilder.RenameTable(
                name: "MeasureType",
                newName: "MeasureTypes");

            migrationBuilder.RenameTable(
                name: "MachineToolType",
                newName: "MachineToolTypes");

            migrationBuilder.AlterColumn<int>(
                name: "MachineToolId",
                table: "Sensor",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Activity_LastActiveDateTime",
                table: "Sensor",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<bool>(
                name: "Activity_IsActive",
                table: "Sensor",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeasureTypes",
                table: "MeasureTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MachineToolTypes",
                table: "MachineToolTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineTool_MachineToolTypes_MachineToolTypeId",
                table: "MachineTool",
                column: "MachineToolTypeId",
                principalTable: "MachineToolTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sensor_MachineTool_MachineToolId",
                table: "Sensor",
                column: "MachineToolId",
                principalTable: "MachineTool",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sensor_MeasureTypes_MeasureTypeId",
                table: "Sensor",
                column: "MeasureTypeId",
                principalTable: "MeasureTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineTool_MachineToolTypes_MachineToolTypeId",
                table: "MachineTool");

            migrationBuilder.DropForeignKey(
                name: "FK_Sensor_MachineTool_MachineToolId",
                table: "Sensor");

            migrationBuilder.DropForeignKey(
                name: "FK_Sensor_MeasureTypes_MeasureTypeId",
                table: "Sensor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MeasureTypes",
                table: "MeasureTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MachineToolTypes",
                table: "MachineToolTypes");

            migrationBuilder.RenameTable(
                name: "MeasureTypes",
                newName: "MeasureType");

            migrationBuilder.RenameTable(
                name: "MachineToolTypes",
                newName: "MachineToolType");

            migrationBuilder.AlterColumn<int>(
                name: "MachineToolId",
                table: "Sensor",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Activity_LastActiveDateTime",
                table: "Sensor",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Activity_IsActive",
                table: "Sensor",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MeasureType",
                table: "MeasureType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MachineToolType",
                table: "MachineToolType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineTool_MachineToolType_MachineToolTypeId",
                table: "MachineTool",
                column: "MachineToolTypeId",
                principalTable: "MachineToolType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sensor_MachineTool_MachineToolId",
                table: "Sensor",
                column: "MachineToolId",
                principalTable: "MachineTool",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sensor_MeasureType_MeasureTypeId",
                table: "Sensor",
                column: "MeasureTypeId",
                principalTable: "MeasureType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
