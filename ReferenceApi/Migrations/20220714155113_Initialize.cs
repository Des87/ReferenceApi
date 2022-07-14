using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReferenceApi.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Condition",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    Icon = table.Column<string>(type: "TEXT", nullable: true),
                    Code = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Region = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    Lat = table.Column<decimal>(type: "TEXT", nullable: false),
                    Lon = table.Column<decimal>(type: "TEXT", nullable: false),
                    Tz_id = table.Column<string>(type: "TEXT", nullable: true),
                    Localtime_epoch = table.Column<string>(type: "TEXT", nullable: true),
                    Localtime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Current",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Last_updated_epoch = table.Column<string>(type: "TEXT", nullable: true),
                    Last_updated = table.Column<string>(type: "TEXT", nullable: true),
                    Temp_c = table.Column<string>(type: "TEXT", nullable: true),
                    Temp_f = table.Column<string>(type: "TEXT", nullable: true),
                    Is_day = table.Column<string>(type: "TEXT", nullable: true),
                    Wind_mph = table.Column<decimal>(type: "TEXT", nullable: false),
                    Wind_kph = table.Column<decimal>(type: "TEXT", nullable: false),
                    Wind_degree = table.Column<decimal>(type: "TEXT", nullable: false),
                    Wind_dir = table.Column<string>(type: "TEXT", nullable: true),
                    Pressure_mb = table.Column<decimal>(type: "TEXT", nullable: false),
                    Pressure_in = table.Column<decimal>(type: "TEXT", nullable: false),
                    Precip_mm = table.Column<decimal>(type: "TEXT", nullable: false),
                    Precip_in = table.Column<decimal>(type: "TEXT", nullable: false),
                    Humidity = table.Column<decimal>(type: "TEXT", nullable: false),
                    Cloud = table.Column<decimal>(type: "TEXT", nullable: false),
                    Feelslike_c = table.Column<decimal>(type: "TEXT", nullable: false),
                    Feelslike_f = table.Column<decimal>(type: "TEXT", nullable: false),
                    Vis_km = table.Column<decimal>(type: "TEXT", nullable: false),
                    Vis_miles = table.Column<decimal>(type: "TEXT", nullable: false),
                    Uv = table.Column<decimal>(type: "TEXT", nullable: false),
                    Gust_mph = table.Column<decimal>(type: "TEXT", nullable: false),
                    Gust_kph = table.Column<decimal>(type: "TEXT", nullable: false),
                    ConditionId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Current", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Current_Condition_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "Condition",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Weather",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LocationId = table.Column<Guid>(type: "TEXT", nullable: true),
                    CurrentId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weather", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weather_Current_CurrentId",
                        column: x => x.CurrentId,
                        principalTable: "Current",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Weather_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Current_ConditionId",
                table: "Current",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Weather_CurrentId",
                table: "Weather",
                column: "CurrentId");

            migrationBuilder.CreateIndex(
                name: "IX_Weather_LocationId",
                table: "Weather",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Weather");

            migrationBuilder.DropTable(
                name: "Current");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Condition");
        }
    }
}
