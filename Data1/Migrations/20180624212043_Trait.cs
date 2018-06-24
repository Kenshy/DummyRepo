using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Data1.Migrations
{
    public partial class Trait : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RandomEntities",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MaxVal = table.Column<decimal>(nullable: false),
                    MinVal = table.Column<decimal>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandomEntities", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RandomEntities");
        }
    }
}
