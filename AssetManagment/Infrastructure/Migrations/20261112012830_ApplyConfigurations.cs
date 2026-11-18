using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ApplyConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToMachineTool",
                table: "SensorMovements",
                newName: "ToMachineToolId");

            migrationBuilder.RenameColumn(
                name: "FromMachineTool",
                table: "SensorMovements",
                newName: "FromMachineToolId");

            migrationBuilder.RenameColumn(
                name: "LastActiveDateTime",
                table: "Sensor",
                newName: "Activity_LastActiveDateTime");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Sensor",
                newName: "Activity_IsActive");

            migrationBuilder.RenameColumn(
                name: "LastActiveDateTime",
                table: "MachineTool",
                newName: "Activity_LastActiveDateTime");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "MachineTool",
                newName: "Activity_IsActive");

            migrationBuilder.RenameColumn(
                name: "ToolTypeId",
                table: "MachineTool",
                newName: "MachineToolTypeId");

            migrationBuilder.CreateTable(
                name: "MachineToolType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Group = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineToolType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MeasureType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasureType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SensorMovements_FromMachineToolId",
                table: "SensorMovements",
                column: "FromMachineToolId");

            migrationBuilder.CreateIndex(
                name: "IX_SensorMovements_SensorId",
                table: "SensorMovements",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_SensorMovements_ToMachineToolId",
                table: "SensorMovements",
                column: "ToMachineToolId");

            migrationBuilder.CreateIndex(
                name: "IX_Sensor_MeasureTypeId",
                table: "Sensor",
                column: "MeasureTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MachineTool_MachineToolTypeId",
                table: "MachineTool",
                column: "MachineToolTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineTool_MachineToolType_MachineToolTypeId",
                table: "MachineTool",
                column: "MachineToolTypeId",
                principalTable: "MachineToolType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sensor_MeasureType_MeasureTypeId",
                table: "Sensor",
                column: "MeasureTypeId",
                principalTable: "MeasureType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SensorMovements_MachineTool_FromMachineToolId",
                table: "SensorMovements",
                column: "FromMachineToolId",
                principalTable: "MachineTool",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SensorMovements_MachineTool_ToMachineToolId",
                table: "SensorMovements",
                column: "ToMachineToolId",
                principalTable: "MachineTool",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SensorMovements_Sensor_SensorId",
                table: "SensorMovements",
                column: "SensorId",
                principalTable: "Sensor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineTool_MachineToolType_MachineToolTypeId",
                table: "MachineTool");

            migrationBuilder.DropForeignKey(
                name: "FK_Sensor_MeasureType_MeasureTypeId",
                table: "Sensor");

            migrationBuilder.DropForeignKey(
                name: "FK_SensorMovements_MachineTool_FromMachineToolId",
                table: "SensorMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_SensorMovements_MachineTool_ToMachineToolId",
                table: "SensorMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_SensorMovements_Sensor_SensorId",
                table: "SensorMovements");

            migrationBuilder.DropTable(
                name: "MachineToolType");

            migrationBuilder.DropTable(
                name: "MeasureType");

            migrationBuilder.DropIndex(
                name: "IX_SensorMovements_FromMachineToolId",
                table: "SensorMovements");

            migrationBuilder.DropIndex(
                name: "IX_SensorMovements_SensorId",
                table: "SensorMovements");

            migrationBuilder.DropIndex(
                name: "IX_SensorMovements_ToMachineToolId",
                table: "SensorMovements");

            migrationBuilder.DropIndex(
                name: "IX_Sensor_MeasureTypeId",
                table: "Sensor");

            migrationBuilder.DropIndex(
                name: "IX_MachineTool_MachineToolTypeId",
                table: "MachineTool");

            migrationBuilder.RenameColumn(
                name: "ToMachineToolId",
                table: "SensorMovements",
                newName: "ToMachineTool");

            migrationBuilder.RenameColumn(
                name: "FromMachineToolId",
                table: "SensorMovements",
                newName: "FromMachineTool");

            migrationBuilder.RenameColumn(
                name: "Activity_LastActiveDateTime",
                table: "Sensor",
                newName: "LastActiveDateTime");

            migrationBuilder.RenameColumn(
                name: "Activity_IsActive",
                table: "Sensor",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "Activity_LastActiveDateTime",
                table: "MachineTool",
                newName: "LastActiveDateTime");

            migrationBuilder.RenameColumn(
                name: "Activity_IsActive",
                table: "MachineTool",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "MachineToolTypeId",
                table: "MachineTool",
                newName: "ToolTypeId");
        }
    }
}
