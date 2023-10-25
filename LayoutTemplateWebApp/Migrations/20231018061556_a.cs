using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LayoutTemplateWebApp.Migrations
{
    /// <inheritdoc />
    public partial class a : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EventC#",
                table: "EventC#");

            migrationBuilder.RenameTable(
                name: "EventC#",
                newName: "Event");

            migrationBuilder.AlterColumn<int>(
                name: "idBuildingType",
                table: "Facility",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AlterColumn<int>(
                name: "capacity",
                table: "Facility",
                type: "int",
                nullable: false,
                oldClrType: typeof(short),
                oldType: "smallint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "idEvent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "EventC#");

            migrationBuilder.AlterColumn<short>(
                name: "idBuildingType",
                table: "Facility",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<short>(
                name: "capacity",
                table: "Facility",
                type: "smallint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventC#",
                table: "EventC#",
                column: "idEvent");
        }
    }
}
