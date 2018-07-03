using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Data1.Migrations
{
    public partial class TraitRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RandomEntities",
                table: "RandomEntities");

            migrationBuilder.RenameTable(
                name: "RandomEntities",
                newName: "Traits");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Traits",
                table: "Traits",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Traits",
                table: "Traits");

            migrationBuilder.RenameTable(
                name: "Traits",
                newName: "RandomEntities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RandomEntities",
                table: "RandomEntities",
                column: "Id");
        }
    }
}
