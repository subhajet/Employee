using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeRAWebApi.Migrations
{
    /// <inheritdoc />
    public partial class CachDB10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee_RA_Subhajit",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_RA_Subhajit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmpRA_LoginLogs_Subhajit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoginTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LogoutTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpRA_LoginLogs_Subhajit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmpRA_Roles_Subhajit",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpRA_Roles_Subhajit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmpRA_UserClaims_Subhajit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpRA_UserClaims_Subhajit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpRA_UserClaims_Subhajit_Employee_RA_Subhajit_UserId",
                        column: x => x.UserId,
                        principalTable: "Employee_RA_Subhajit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpRA_UserLogins_Subhajit",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpRA_UserLogins_Subhajit", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_EmpRA_UserLogins_Subhajit_Employee_RA_Subhajit_UserId",
                        column: x => x.UserId,
                        principalTable: "Employee_RA_Subhajit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpRA_UserTokens_Subhajit",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpRA_UserTokens_Subhajit", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_EmpRA_UserTokens_Subhajit_Employee_RA_Subhajit_UserId",
                        column: x => x.UserId,
                        principalTable: "Employee_RA_Subhajit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpRA_RoleClaims_Subhajit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpRA_RoleClaims_Subhajit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmpRA_RoleClaims_Subhajit_EmpRA_Roles_Subhajit_RoleId",
                        column: x => x.RoleId,
                        principalTable: "EmpRA_Roles_Subhajit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmpRA_UserRoles_Subhajit",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmpRA_UserRoles_Subhajit", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_EmpRA_UserRoles_Subhajit_EmpRA_Roles_Subhajit_RoleId",
                        column: x => x.RoleId,
                        principalTable: "EmpRA_Roles_Subhajit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmpRA_UserRoles_Subhajit_Employee_RA_Subhajit_UserId",
                        column: x => x.UserId,
                        principalTable: "Employee_RA_Subhajit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Employee_RA_Subhajit",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Employee_RA_Subhajit",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EmpRA_RoleClaims_Subhajit_RoleId",
                table: "EmpRA_RoleClaims_Subhajit",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "EmpRA_Roles_Subhajit",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EmpRA_UserClaims_Subhajit_UserId",
                table: "EmpRA_UserClaims_Subhajit",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpRA_UserLogins_Subhajit_UserId",
                table: "EmpRA_UserLogins_Subhajit",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmpRA_UserRoles_Subhajit_RoleId",
                table: "EmpRA_UserRoles_Subhajit",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmpRA_LoginLogs_Subhajit");

            migrationBuilder.DropTable(
                name: "EmpRA_RoleClaims_Subhajit");

            migrationBuilder.DropTable(
                name: "EmpRA_UserClaims_Subhajit");

            migrationBuilder.DropTable(
                name: "EmpRA_UserLogins_Subhajit");

            migrationBuilder.DropTable(
                name: "EmpRA_UserRoles_Subhajit");

            migrationBuilder.DropTable(
                name: "EmpRA_UserTokens_Subhajit");

            migrationBuilder.DropTable(
                name: "EmpRA_Roles_Subhajit");

            migrationBuilder.DropTable(
                name: "Employee_RA_Subhajit");
        }
    }
}
