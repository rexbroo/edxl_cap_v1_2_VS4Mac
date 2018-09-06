using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace edxl_cap_v1_2.Migrations
{
    public partial class _20180718_MasterBranchUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AlterColumn<string>(
                name: "Alert_Identifier",
                table: "Resource",
                maxLength: 150,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Alert_Identifier",
                table: "Info",
                maxLength: 150,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Alert_Identifier",
                table: "Area",
                maxLength: 150,
                nullable: false);

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alert_EdxlCapMessageViewModel_Alert_Identifier",
                table: "Alert");

            migrationBuilder.DropForeignKey(
                name: "FK_Area_EdxlCapMessageViewModel_Alert_Identifier",
                table: "Area");

            migrationBuilder.DropForeignKey(
                name: "FK_Element_Alert_AlertIndex",
                table: "Element");

            migrationBuilder.DropForeignKey(
                name: "FK_Info_EdxlCapMessageViewModel_Alert_Identifier",
                table: "Info");

            migrationBuilder.DropForeignKey(
                name: "FK_Resource_EdxlCapMessageViewModel_Alert_Identifier",
                table: "Resource");

            migrationBuilder.DropTable(
                name: "EdxlCapMessageViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Resource_Alert_Identifier",
                table: "Resource");

            migrationBuilder.DropIndex(
                name: "IX_Info_Alert_Identifier",
                table: "Info");

            migrationBuilder.DropIndex(
                name: "IX_Area_Alert_Identifier",
                table: "Area");

            migrationBuilder.DropIndex(
                name: "IX_Alert_Alert_Identifier",
                table: "Alert");

            migrationBuilder.DropColumn(
                name: "Alert_Identifier",
                table: "Resource");

            migrationBuilder.DropColumn(
                name: "Alert_Identifier",
                table: "Info");

            migrationBuilder.DropColumn(
                name: "Alert_Identifier",
                table: "Area");

            migrationBuilder.DropColumn(
                name: "Alert_Identifier",
                table: "Alert");

            migrationBuilder.RenameColumn(
                name: "Language",
                table: "Info",
                newName: "language");

            migrationBuilder.RenameColumn(
                name: "AlertIndex",
                table: "Element",
                newName: "AlertId");

            migrationBuilder.RenameColumn(
                name: "ElementIndex",
                table: "Element",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Element_AlertIndex",
                table: "Element",
                newName: "IX_Element_AlertId");

            migrationBuilder.RenameColumn(
                name: "AlertIndex",
                table: "Alert",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "Identifier",
                table: "Alert",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "Alert",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Element_Alert_AlertId",
                table: "Element",
                column: "AlertId",
                principalTable: "Alert",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
