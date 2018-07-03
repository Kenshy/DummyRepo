using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Data1.Migrations
{
    public partial class TraitFormat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Traits",
                table: "Traits");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Traits",
                table: "Traits",
                columns: new[] { "Id", "MinVal", "MaxVal" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Traits",
                table: "Traits");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Traits",
                table: "Traits",
                column: "Id");
        }
    }
}
