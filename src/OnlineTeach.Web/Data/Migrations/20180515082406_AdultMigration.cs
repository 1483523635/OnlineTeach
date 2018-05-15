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

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
          
            migrationBuilder.DropTable(
                name: "TeacherApplies");

           
        }
    }
}
