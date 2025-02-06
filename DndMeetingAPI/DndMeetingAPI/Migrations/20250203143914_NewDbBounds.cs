using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DndMeetingAPI.Migrations
{
    /// <inheritdoc />
    public partial class NewDbBounds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DayWithFreeTimes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Date = table.Column<DateOnly>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayWithFreeTimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FreeTimes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DayWithFreeTimeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreeTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FreeTimes_DayWithFreeTimes_DayWithFreeTimeId",
                        column: x => x.DayWithFreeTimeId,
                        principalTable: "DayWithFreeTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FreeTimes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersAndDaysWithFreeTimes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DayWithFreeTimeId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersAndDaysWithFreeTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersAndDaysWithFreeTimes_DayWithFreeTimes_DayWithFreeTimeId",
                        column: x => x.DayWithFreeTimeId,
                        principalTable: "DayWithFreeTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersAndDaysWithFreeTimes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FreeTimes_DayWithFreeTimeId",
                table: "FreeTimes",
                column: "DayWithFreeTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_FreeTimes_UserId",
                table: "FreeTimes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersAndDaysWithFreeTimes_DayWithFreeTimeId",
                table: "UsersAndDaysWithFreeTimes",
                column: "DayWithFreeTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersAndDaysWithFreeTimes_UserId",
                table: "UsersAndDaysWithFreeTimes",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FreeTimes");

            migrationBuilder.DropTable(
                name: "UsersAndDaysWithFreeTimes");

            migrationBuilder.DropTable(
                name: "DayWithFreeTimes");
        }
    }
}
