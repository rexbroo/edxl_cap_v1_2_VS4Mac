using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace edxl_cap_v1_2.Migrations
{
    public partial class InfoEdit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EdxlCapMessageViewModel_Info_InfoIndex",
                table: "EdxlCapMessageViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Element_Info_InfoIndex",
                table: "Element");

            migrationBuilder.RenameColumn(
                name: "InfoIndex",
                table: "Info",
                newName: "AreaIndex");

            migrationBuilder.RenameColumn(
                name: "InfoIndex",
                table: "Element",
                newName: "InfoAreaIndex");

            migrationBuilder.RenameIndex(
                name: "IX_Element_InfoIndex",
                table: "Element",
                newName: "IX_Element_InfoAreaIndex");

            migrationBuilder.RenameColumn(
                name: "InfoIndex",
                table: "EdxlCapMessageViewModel",
                newName: "InfoAreaIndex");

            migrationBuilder.RenameIndex(
                name: "IX_EdxlCapMessageViewModel_InfoIndex",
                table: "EdxlCapMessageViewModel",
                newName: "IX_EdxlCapMessageViewModel_InfoAreaIndex");

            migrationBuilder.AddForeignKey(
                name: "FK_EdxlCapMessageViewModel_Info_InfoAreaIndex",
                table: "EdxlCapMessageViewModel",
                column: "InfoAreaIndex",
                principalTable: "Info",
                principalColumn: "AreaIndex",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Element_Info_InfoAreaIndex",
                table: "Element",
                column: "InfoAreaIndex",
                principalTable: "Info",
                principalColumn: "AreaIndex",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
