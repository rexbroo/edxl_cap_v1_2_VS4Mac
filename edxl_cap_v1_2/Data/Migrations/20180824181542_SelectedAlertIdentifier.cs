using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace edxl_cap_v1_2.Migrations
{
    public partial class SelectedAlertIdentifier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Alert_Identifier",
                table: "Info",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SelectedAlertIndex",
                table: "Alert",
                nullable: false,
                defaultValue: 0);

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EdxlCapMsg");

            migrationBuilder.DropColumn(
                name: "SelectedAlertIndex",
                table: "Alert");

            migrationBuilder.AlterColumn<string>(
                name: "Alert_Identifier",
                table: "Resource",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Alert_Identifier",
                table: "Info",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150,
                oldNullable: true);
        }
    }
}
