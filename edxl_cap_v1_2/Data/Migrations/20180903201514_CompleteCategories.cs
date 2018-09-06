using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace edxl_cap_v1_2.Migrations
{
    public partial class CompleteCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        
            migrationBuilder.AddColumn<int>(
                name: "SelectedAlertIndex",
                table: "EdxlCapMsg",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SelectedAreaIndex",
                table: "EdxlCapMsg",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SelectedInfoIndex",
                table: "EdxlCapMsg",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SelectedResourceIndex",
                table: "EdxlCapMsg",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AlertViewModel",
                columns: table => new
                {
                    AlertIndex = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    SelectedAlertIndex = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertViewModel", x => x.AlertIndex);
                });

            migrationBuilder.CreateTable(
                name: "AlertVm",
                columns: table => new
                {
                    AlertIndex = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AlertViewModelAlertIndex = table.Column<int>(nullable: true),
                    Alert_Identifier = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertVm", x => x.AlertIndex);
                    table.ForeignKey(
                        name: "FK_AlertVm_AlertViewModel_AlertViewModelAlertIndex",
                        column: x => x.AlertViewModelAlertIndex,
                        principalTable: "AlertViewModel",
                        principalColumn: "AlertIndex",
                        onDelete: ReferentialAction.Restrict);
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EdxlCapMessageViewModel_Alert_AlertIndex1",
                table: "EdxlCapMessageViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_EdxlCapMessageViewModel_Area_AreaIndex",
                table: "EdxlCapMessageViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_EdxlCapMessageViewModel_Info_InfoAreaIndex",
                table: "EdxlCapMessageViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_EdxlCapMessageViewModel_Resource_ResourceIndex",
                table: "EdxlCapMessageViewModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Element_Info_InfoAreaIndex",
                table: "Element");

            migrationBuilder.DropTable(
                name: "AlertVm");

            migrationBuilder.DropTable(
                name: "AlertViewModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EdxlCapMessageViewModel",
                table: "EdxlCapMessageViewModel");

            migrationBuilder.DropIndex(
                name: "IX_EdxlCapMessageViewModel_AlertIndex1",
                table: "EdxlCapMessageViewModel");

            migrationBuilder.DropIndex(
                name: "IX_EdxlCapMessageViewModel_AreaIndex",
                table: "EdxlCapMessageViewModel");

            migrationBuilder.DropIndex(
                name: "IX_EdxlCapMessageViewModel_InfoAreaIndex",
                table: "EdxlCapMessageViewModel");

            migrationBuilder.DropIndex(
                name: "IX_EdxlCapMessageViewModel_ResourceIndex",
                table: "EdxlCapMessageViewModel");

            migrationBuilder.DropColumn(
                name: "AreaIndex",
                table: "EdxlCapMsg");

            migrationBuilder.DropColumn(
                name: "InfoIndex",
                table: "EdxlCapMsg");

            migrationBuilder.DropColumn(
                name: "ResourceIndex",
                table: "EdxlCapMsg");

            migrationBuilder.DropColumn(
                name: "SelectedAlertIndex",
                table: "EdxlCapMsg");

            migrationBuilder.DropColumn(
                name: "SelectedAreaIndex",
                table: "EdxlCapMsg");

            migrationBuilder.DropColumn(
                name: "SelectedInfoIndex",
                table: "EdxlCapMsg");

            migrationBuilder.DropColumn(
                name: "SelectedResourceIndex",
                table: "EdxlCapMsg");

            migrationBuilder.DropColumn(
                name: "AlertIndex",
                table: "EdxlCapMessageViewModel");

            migrationBuilder.DropColumn(
                name: "AlertIndex1",
                table: "EdxlCapMessageViewModel");

            migrationBuilder.DropColumn(
                name: "AreaIndex",
                table: "EdxlCapMessageViewModel");

            migrationBuilder.DropColumn(
                name: "InfoAreaIndex",
                table: "EdxlCapMessageViewModel");

            migrationBuilder.DropColumn(
                name: "ResourceIndex",
                table: "EdxlCapMessageViewModel");

            migrationBuilder.RenameColumn(
                name: "InfoAreaIndex",
                table: "Element",
                newName: "InfoIndex");

            migrationBuilder.RenameIndex(
                name: "IX_Element_InfoAreaIndex",
                table: "Element",
                newName: "IX_Element_InfoIndex");

            migrationBuilder.RenameColumn(
                name: "AreaIndex",
                table: "Info",
                newName: "InfoIndex");

            migrationBuilder.AlterColumn<string>(
                name: "Alert_Identifier",
                table: "EdxlCapMessageViewModel",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EdxlCapMessageViewModel",
                table: "EdxlCapMessageViewModel",
                column: "Alert_Identifier");

            migrationBuilder.CreateIndex(
                name: "IX_Alert_Alert_Identifier",
                table: "Alert",
                column: "Alert_Identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resource_Alert_Identifier",
                table: "Resource",
                column: "Alert_Identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Info_Alert_Identifier",
                table: "Info",
                column: "Alert_Identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Area_Alert_Identifier",
                table: "Area",
                column: "Alert_Identifier",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Alert_EdxlCapMessageViewModel_Alert_Identifier",
                table: "Alert",
                column: "Alert_Identifier",
                principalTable: "EdxlCapMessageViewModel",
                principalColumn: "Alert_Identifier",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Area_EdxlCapMessageViewModel_Alert_Identifier",
                table: "Area",
                column: "Alert_Identifier",
                principalTable: "EdxlCapMessageViewModel",
                principalColumn: "Alert_Identifier",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Element_Info_InfoIndex",
                table: "Element",
                column: "InfoIndex",
                principalTable: "Info",
                principalColumn: "InfoIndex",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Info_EdxlCapMessageViewModel_Alert_Identifier",
                table: "Info",
                column: "Alert_Identifier",
                principalTable: "EdxlCapMessageViewModel",
                principalColumn: "Alert_Identifier",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Resource_EdxlCapMessageViewModel_Alert_Identifier",
                table: "Resource",
                column: "Alert_Identifier",
                principalTable: "EdxlCapMessageViewModel",
                principalColumn: "Alert_Identifier",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
