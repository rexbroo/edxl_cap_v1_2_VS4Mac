using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace edxl_cap_v1_2.Migrations
{
    public partial class CreateIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alert",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Addresses = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    DataCategory_Id = table.Column<int>(nullable: false),
                    Identifier = table.Column<string>(nullable: true),
                    Incidents = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    MsgType = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true),
                    References = table.Column<string>(nullable: true),
                    Restriction = table.Column<string>(nullable: true),
                    Scope = table.Column<int>(nullable: false),
                    Sender = table.Column<string>(nullable: true),
                    Sent = table.Column<DateTime>(nullable: false),
                    Source = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alert", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    AreaIndex = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Altitude = table.Column<string>(nullable: true),
                    AreaDesc = table.Column<string>(nullable: true),
                    Ceiling = table.Column<string>(nullable: true),
                    Circle = table.Column<string>(nullable: true),
                    DataCategory_Id = table.Column<int>(nullable: false),
                    Geocode = table.Column<string>(nullable: true),
                    Polygon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.AreaIndex);
                });

            migrationBuilder.CreateTable(
                name: "DataCategory",
                columns: table => new
                {
                    DataCategory_Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    DataCategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataCategory", x => x.DataCategory_Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityRole<string>",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 200, nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole<string>", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IdentityUser<string>",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 200, nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser<string>", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Info",
                columns: table => new
                {
                    InfoIndex = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Audience = table.Column<string>(nullable: true),
                    Category = table.Column<int>(nullable: false),
                    Certainty = table.Column<int>(nullable: false),
                    Contact = table.Column<string>(nullable: true),
                    DataCategory_Id = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Effective = table.Column<DateTime>(nullable: false),
                    Event = table.Column<string>(nullable: true),
                    EventCode = table.Column<string>(nullable: true),
                    Expires = table.Column<DateTime>(nullable: false),
                    Headline = table.Column<string>(nullable: true),
                    Instruction = table.Column<string>(nullable: true),
                    Onset = table.Column<DateTime>(nullable: false),
                    Parameter = table.Column<string>(nullable: true),
                    ResponseType = table.Column<int>(nullable: false),
                    SenderName = table.Column<string>(nullable: true),
                    Severity = table.Column<int>(nullable: false),
                    Urgency = table.Column<int>(nullable: false),
                    Web = table.Column<string>(nullable: true),
                    language = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Info", x => x.InfoIndex);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    PersonName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    ResourceIndex = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    DataCategory_Id = table.Column<int>(nullable: false),
                    DerefUri = table.Column<string>(nullable: true),
                    Digest = table.Column<string>(nullable: true),
                    Info_Alert_Identifier = table.Column<string>(nullable: true),
                    MimeType = table.Column<string>(nullable: true),
                    ResourceDesc = table.Column<string>(nullable: true),
                    Size = table.Column<int>(nullable: false),
                    Uri = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.ResourceIndex);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_IdentityRole<string>_RoleId",
                        column: x => x.RoleId,
                        principalTable: "IdentityRole<string>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_IdentityUser<string>_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUser<string>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 200, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 200, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_IdentityUser<string>_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUser<string>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(maxLength: 200, nullable: false),
                    RoleId = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_IdentityRole<string>_RoleId",
                        column: x => x.RoleId,
                        principalTable: "IdentityRole<string>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_IdentityUser<string>_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUser<string>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 200, nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_IdentityUser<string>_UserId",
                        column: x => x.UserId,
                        principalTable: "IdentityUser<string>",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Element",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AlertId = table.Column<int>(nullable: true),
                    AreaIndex = table.Column<int>(nullable: true),
                    DataCategory_Id1 = table.Column<int>(nullable: true),
                    ElementName = table.Column<string>(nullable: true),
                    InfoIndex = table.Column<int>(nullable: true),
                    ResourceIndex = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Element", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Element_Alert_AlertId",
                        column: x => x.AlertId,
                        principalTable: "Alert",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Element_Area_AreaIndex",
                        column: x => x.AreaIndex,
                        principalTable: "Area",
                        principalColumn: "AreaIndex",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Element_DataCategory_DataCategory_Id1",
                        column: x => x.DataCategory_Id1,
                        principalTable: "DataCategory",
                        principalColumn: "DataCategory_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Element_Info_InfoIndex",
                        column: x => x.InfoIndex,
                        principalTable: "Info",
                        principalColumn: "InfoIndex",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Element_Resource_ResourceIndex",
                        column: x => x.ResourceIndex,
                        principalTable: "Resource",
                        principalColumn: "ResourceIndex",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Element_AlertId",
                table: "Element",
                column: "AlertId");

            migrationBuilder.CreateIndex(
                name: "IX_Element_AreaIndex",
                table: "Element",
                column: "AreaIndex");

            migrationBuilder.CreateIndex(
                name: "IX_Element_DataCategory_Id1",
                table: "Element",
                column: "DataCategory_Id1");

            migrationBuilder.CreateIndex(
                name: "IX_Element_InfoIndex",
                table: "Element",
                column: "InfoIndex");

            migrationBuilder.CreateIndex(
                name: "IX_Element_ResourceIndex",
                table: "Element",
                column: "ResourceIndex");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Element");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "IdentityRole<string>");

            migrationBuilder.DropTable(
                name: "IdentityUser<string>");

            migrationBuilder.DropTable(
                name: "Alert");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "DataCategory");

            migrationBuilder.DropTable(
                name: "Info");

            migrationBuilder.DropTable(
                name: "Resource");
        }
    }
}
