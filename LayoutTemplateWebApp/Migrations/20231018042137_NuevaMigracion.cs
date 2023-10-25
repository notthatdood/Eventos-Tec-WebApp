using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LayoutTemplateWebApp.Migrations
{
    /// <inheritdoc />
    public partial class NuevaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Constraints",
                columns: table => new
                {
                    idConstraint = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Constraints", x => x.idConstraint);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    idEvent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idEventState = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    organizer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maxCapacity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    entryCost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idEventType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.idEvent);
                });

            migrationBuilder.CreateTable(
                name: "Facility",
                columns: table => new
                {
                    idFacility = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idBuildingType = table.Column<int>(type: "int", nullable: false),
                    capacity = table.Column<int>(type: "int", nullable: false),
                    idLocation = table.Column<int>(type: "int", nullable: false),
                    idFacilityAdministrator = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facility", x => x.idFacility);
                });

            migrationBuilder.CreateTable(
                name: "FacilityAdministrators",
                columns: table => new
                {
                    idFacilityAdministrator = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityAdministrators", x => x.idFacilityAdministrator);
                });

            migrationBuilder.CreateTable(
                name: "FacilityTypes",
                columns: table => new
                {
                    idFacilityType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilityTypes", x => x.idFacilityType);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    idLocation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    coordinates = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    inCampus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.idLocation);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    personPassword = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    cardNumber = table.Column<int>(type: "int", nullable: false),
                    personName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    firstLastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    secondLastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    debt = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Constraints");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Facility");

            migrationBuilder.DropTable(
                name: "FacilityAdministrators");

            migrationBuilder.DropTable(
                name: "FacilityTypes");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
