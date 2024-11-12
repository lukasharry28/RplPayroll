using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebPayroll.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    BankId = table.Column<string>(type: "TEXT", nullable: false),
                    BankName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.BankId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<string>(type: "TEXT", nullable: false),
                    CountryName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DeptId = table.Column<string>(type: "TEXT", nullable: false),
                    DeptName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DeptId);
                });

            migrationBuilder.CreateTable(
                name: "RekeningBanks",
                columns: table => new
                {
                    RekBankId = table.Column<string>(type: "TEXT", nullable: false),
                    BankId = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Saldo = table.Column<decimal>(type: "TEXT", nullable: false),
                    ActiveStatus = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RekeningBanks", x => x.RekBankId);
                    table.ForeignKey(
                        name: "FK_RekeningBanks_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "BankId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<string>(type: "TEXT", nullable: false),
                    CityName = table.Column<string>(type: "TEXT", nullable: false),
                    CountryId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PosId = table.Column<string>(type: "TEXT", nullable: false),
                    DeptId = table.Column<string>(type: "TEXT", nullable: false),
                    PosName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PosId);
                    table.ForeignKey(
                        name: "FK_Positions_Departments_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Departments",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CmpId = table.Column<string>(type: "TEXT", nullable: false),
                    CmpName = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    RekBankId = table.Column<string>(type: "TEXT", nullable: false),
                    CityId = table.Column<string>(type: "TEXT", nullable: false),
                    RekeningBankRekBankId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CmpId);
                    table.ForeignKey(
                        name: "FK_Companies_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Companies_RekeningBanks_RekeningBankRekBankId",
                        column: x => x.RekeningBankRekBankId,
                        principalTable: "RekeningBanks",
                        principalColumn: "RekBankId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmpId = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Gender = table.Column<string>(type: "TEXT", nullable: false),
                    Birthday = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Religion = table.Column<string>(type: "TEXT", nullable: false),
                    CityId = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    RekBankId = table.Column<string>(type: "TEXT", nullable: false),
                    HireDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CmpId = table.Column<string>(type: "TEXT", nullable: false),
                    PosId = table.Column<string>(type: "TEXT", nullable: false),
                    PositionPosId = table.Column<string>(type: "TEXT", nullable: false),
                    ImageName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmpId);
                    table.ForeignKey(
                        name: "FK_Employees_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Companies_CmpId",
                        column: x => x.CmpId,
                        principalTable: "Companies",
                        principalColumn: "CmpId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PositionPosId",
                        column: x => x.PositionPosId,
                        principalTable: "Positions",
                        principalColumn: "PosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SchedulePayrolls",
                columns: table => new
                {
                    ScdId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CmpId = table.Column<string>(type: "TEXT", nullable: false),
                    PayrollFrekens = table.Column<string>(type: "TEXT", nullable: false),
                    PayrollDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CountryId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchedulePayrolls", x => x.ScdId);
                    table.ForeignKey(
                        name: "FK_SchedulePayrolls_Companies_CmpId",
                        column: x => x.CmpId,
                        principalTable: "Companies",
                        principalColumn: "CmpId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SchedulePayrolls_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId");
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    EmpId = table.Column<string>(type: "TEXT", nullable: false),
                    FailedLoginAttempts = table.Column<int>(type: "INTEGER", nullable: false),
                    LockoutEndTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CurrentOtpCode = table.Column<string>(type: "TEXT", nullable: true),
                    OtpExpiration = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_Employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employees",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payrolls",
                columns: table => new
                {
                    PayId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CmpId = table.Column<string>(type: "TEXT", nullable: false),
                    CompanyCmpId = table.Column<string>(type: "TEXT", nullable: true),
                    EmpId = table.Column<string>(type: "TEXT", nullable: false),
                    ScdId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    RekeningBankRekBankId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payrolls", x => x.PayId);
                    table.ForeignKey(
                        name: "FK_Payrolls_Companies_CompanyCmpId",
                        column: x => x.CompanyCmpId,
                        principalTable: "Companies",
                        principalColumn: "CmpId");
                    table.ForeignKey(
                        name: "FK_Payrolls_Employees_EmpId",
                        column: x => x.EmpId,
                        principalTable: "Employees",
                        principalColumn: "EmpId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payrolls_RekeningBanks_RekeningBankRekBankId",
                        column: x => x.RekeningBankRekBankId,
                        principalTable: "RekeningBanks",
                        principalColumn: "RekBankId");
                    table.ForeignKey(
                        name: "FK_Payrolls_SchedulePayrolls_ScdId",
                        column: x => x.ScdId,
                        principalTable: "SchedulePayrolls",
                        principalColumn: "ScdId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    SessionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    SessionStart = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SessionEnd = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Activities = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.SessionId);
                    table.ForeignKey(
                        name: "FK_Sessions_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailPayrolls",
                columns: table => new
                {
                    DetPayId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PayId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    PayStatus = table.Column<string>(type: "TEXT", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailPayrolls", x => x.DetPayId);
                    table.ForeignKey(
                        name: "FK_DetailPayrolls_Payrolls_PayId",
                        column: x => x.PayId,
                        principalTable: "Payrolls",
                        principalColumn: "PayId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    LoginTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LogoutTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SessionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.LogId);
                    table.ForeignKey(
                        name: "FK_Logs_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Logs_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "SessionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RetryPayrolls",
                columns: table => new
                {
                    RetryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DetPayId = table.Column<int>(type: "INTEGER", nullable: false),
                    RetryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RetryStatus = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetryPayrolls", x => x.RetryId);
                    table.ForeignKey(
                        name: "FK_RetryPayrolls_DetailPayrolls_DetPayId",
                        column: x => x.DetPayId,
                        principalTable: "DetailPayrolls",
                        principalColumn: "DetPayId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_EmpId",
                table: "Accounts",
                column: "EmpId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CityId",
                table: "Companies",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_RekeningBankRekBankId",
                table: "Companies",
                column: "RekeningBankRekBankId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailPayrolls_PayId",
                table: "DetailPayrolls",
                column: "PayId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CityId",
                table: "Employees",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CmpId",
                table: "Employees",
                column: "CmpId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionPosId",
                table: "Employees",
                column: "PositionPosId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_AccountId",
                table: "Logs",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_SessionId",
                table: "Logs",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_CompanyCmpId",
                table: "Payrolls",
                column: "CompanyCmpId");

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_EmpId",
                table: "Payrolls",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_RekeningBankRekBankId",
                table: "Payrolls",
                column: "RekeningBankRekBankId");

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_ScdId",
                table: "Payrolls",
                column: "ScdId");

            migrationBuilder.CreateIndex(
                name: "IX_Positions_DeptId",
                table: "Positions",
                column: "DeptId");

            migrationBuilder.CreateIndex(
                name: "IX_RekeningBanks_BankId",
                table: "RekeningBanks",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_RetryPayrolls_DetPayId",
                table: "RetryPayrolls",
                column: "DetPayId");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulePayrolls_CmpId",
                table: "SchedulePayrolls",
                column: "CmpId");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulePayrolls_CountryId",
                table: "SchedulePayrolls",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_AccountId",
                table: "Sessions",
                column: "AccountId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "RetryPayrolls");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "DetailPayrolls");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Payrolls");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "SchedulePayrolls");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "RekeningBanks");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Banks");
        }
    }
}
