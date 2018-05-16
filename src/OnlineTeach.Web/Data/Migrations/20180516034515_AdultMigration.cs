using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OnlineTeach.Web.Data.Migrations
{
    public partial class AdultMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourceItems",
                columns: table => new
                {
                    key = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookCount = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Grade = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    TeacherName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourceItems", x => x.key);
                });

            migrationBuilder.CreateTable(
                name: "TeacherApplies",
                columns: table => new
                {
                    key = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplyCount = table.Column<int>(nullable: false),
                    ApplyReason = table.Column<string>(nullable: true),
                    ApplyStatus = table.Column<int>(nullable: false),
                    ApplyTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    RealName = table.Column<string>(nullable: true),
                    School = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherApplies", x => x.key);
                });

            migrationBuilder.CreateTable(
                name: "courceOutLines",
                columns: table => new
                {
                    key = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourceId = table.Column<long>(nullable: false),
                    LearnStatu = table.Column<int>(nullable: false),
                    OUtlineName = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    TeacherName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courceOutLines", x => x.key);
                    table.ForeignKey(
                        name: "FK_courceOutLines_CourceItems_CourceId",
                        column: x => x.CourceId,
                        principalTable: "CourceItems",
                        principalColumn: "key",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_courceOutLines_CourceId",
                table: "courceOutLines",
                column: "CourceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "courceOutLines");

            migrationBuilder.DropTable(
                name: "TeacherApplies");

            migrationBuilder.DropTable(
                name: "CourceItems");
        }
    }
}
