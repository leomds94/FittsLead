using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FittsLead.Migrations
{
    public partial class st : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FittsUsers",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Device = table.Column<string>(type: "TEXT", nullable: true),
                    StageCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FittsUsers", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "FittsObjects",
                columns: table => new
                {
                    FittsObjectId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FittsObjects", x => x.FittsObjectId);
                    table.ForeignKey(
                        name: "FK_FittsObjects_FittsUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "FittsUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StageThresholders",
                columns: table => new
                {
                    StageThresholdId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Value = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StageThresholders", x => x.StageThresholdId);
                    table.ForeignKey(
                        name: "FK_StageThresholders_FittsUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "FittsUsers",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClickedPoints",
                columns: table => new
                {
                    ClickedPointId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FittsObjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    Time = table.Column<string>(type: "TEXT", nullable: true),
                    X = table.Column<int>(type: "INTEGER", nullable: false),
                    Y = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClickedPoints", x => x.ClickedPointId);
                    table.ForeignKey(
                        name: "FK_ClickedPoints_FittsObjects_FittsObjectId",
                        column: x => x.FittsObjectId,
                        principalTable: "FittsObjects",
                        principalColumn: "FittsObjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClipRectangles",
                columns: table => new
                {
                    ClipRectangleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FittsObjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    Height = table.Column<int>(type: "INTEGER", nullable: false),
                    Width = table.Column<int>(type: "INTEGER", nullable: false),
                    X = table.Column<int>(type: "INTEGER", nullable: false),
                    Y = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClipRectangles", x => x.ClipRectangleId);
                    table.ForeignKey(
                        name: "FK_ClipRectangles_FittsObjects_FittsObjectId",
                        column: x => x.FittsObjectId,
                        principalTable: "FittsObjects",
                        principalColumn: "FittsObjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    PointId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClickedPointId = table.Column<int>(type: "INTEGER", nullable: false),
                    Time = table.Column<int>(type: "INTEGER", nullable: false),
                    X = table.Column<int>(type: "INTEGER", nullable: false),
                    Y = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Points", x => x.PointId);
                    table.ForeignKey(
                        name: "FK_Points_ClickedPoints_ClickedPointId",
                        column: x => x.ClickedPointId,
                        principalTable: "ClickedPoints",
                        principalColumn: "ClickedPointId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClickedPoints_FittsObjectId",
                table: "ClickedPoints",
                column: "FittsObjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClipRectangles_FittsObjectId",
                table: "ClipRectangles",
                column: "FittsObjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FittsObjects_UserId",
                table: "FittsObjects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Points_ClickedPointId",
                table: "Points",
                column: "ClickedPointId");

            migrationBuilder.CreateIndex(
                name: "IX_StageThresholders_UserId",
                table: "StageThresholders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClipRectangles");

            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropTable(
                name: "StageThresholders");

            migrationBuilder.DropTable(
                name: "ClickedPoints");

            migrationBuilder.DropTable(
                name: "FittsObjects");

            migrationBuilder.DropTable(
                name: "FittsUsers");
        }
    }
}
