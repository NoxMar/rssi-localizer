using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class ExplicitForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Sensors_CapturedById",
                table: "Measurements");

            migrationBuilder.RenameColumn(
                name: "CapturedById",
                table: "Measurements",
                newName: "SensorId");

            migrationBuilder.RenameIndex(
                name: "IX_Measurements_CapturedById",
                table: "Measurements",
                newName: "IX_Measurements_SensorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Sensors_SensorId",
                table: "Measurements",
                column: "SensorId",
                principalTable: "Sensors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Sensors_SensorId",
                table: "Measurements");

            migrationBuilder.RenameColumn(
                name: "SensorId",
                table: "Measurements",
                newName: "CapturedById");

            migrationBuilder.RenameIndex(
                name: "IX_Measurements_SensorId",
                table: "Measurements",
                newName: "IX_Measurements_CapturedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Sensors_CapturedById",
                table: "Measurements",
                column: "CapturedById",
                principalTable: "Sensors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
