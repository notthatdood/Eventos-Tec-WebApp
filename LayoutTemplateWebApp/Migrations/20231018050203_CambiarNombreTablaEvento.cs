using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LayoutTemplateWebApp.Migrations
{
    /// <inheritdoc />
    public partial class CambiarNombreTablaEvento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "EventC#");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventC#",
                table: "EventC#",
                column: "idEvent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EventC#",
                table: "EventC#");

            migrationBuilder.RenameTable(
                name: "EventC#",
                newName: "Event");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "idEvent");
        }
    }
}
