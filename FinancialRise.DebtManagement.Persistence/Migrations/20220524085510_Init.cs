using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinancialRise.DebtManagement.Persistence.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyOperations",
                columns: table => new
                {
                    DailyOperationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    Operation = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyOperations", x => x.DailyOperationId);
                    table.ForeignKey(
                        name: "FK_DailyOperations_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Frequencies",
                columns: table => new
                {
                    FrequencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequencies", x => x.FrequencyId);
                    table.ForeignKey(
                        name: "FK_Frequencies_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    GoalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.GoalId);
                    table.ForeignKey(
                        name: "FK_Goals_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    NoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeOfNote = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.NoteId);
                    table.ForeignKey(
                        name: "FK_Notes_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Savings",
                columns: table => new
                {
                    SavingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalSaving = table.Column<decimal>(type: "money", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Savings", x => x.SavingId);
                    table.ForeignKey(
                        name: "FK_Savings_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Debts",
                columns: table => new
                {
                    DebtId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Instalment = table.Column<decimal>(type: "money", nullable: false),
                    FrequencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Total = table.Column<decimal>(type: "money", nullable: false),
                    LoanAmount = table.Column<decimal>(type: "money", nullable: false),
                    FirstInstalment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastInstalment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InterestRate = table.Column<double>(type: "float", nullable: false),
                    FlatInstalment = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debts", x => x.DebtId);
                    table.ForeignKey(
                        name: "FK_Debts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Debts_Frequencies_FrequencyId",
                        column: x => x.FrequencyId,
                        principalTable: "Frequencies",
                        principalColumn: "FrequencyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incomes",
                columns: table => new
                {
                    IncomeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    FrequencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstRemit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastRemit = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incomes", x => x.IncomeId);
                    table.ForeignKey(
                        name: "FK_Incomes_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incomes_Frequencies_FrequencyId",
                        column: x => x.FrequencyId,
                        principalTable: "Frequencies",
                        principalColumn: "FrequencyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Outcomes",
                columns: table => new
                {
                    OutcomeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    FrequencyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstRemit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastRemit = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outcomes", x => x.OutcomeId);
                    table.ForeignKey(
                        name: "FK_Outcomes_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Outcomes_Frequencies_FrequencyId",
                        column: x => x.FrequencyId,
                        principalTable: "Frequencies",
                        principalColumn: "FrequencyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DebtId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_Contacts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contacts_Debts_DebtId",
                        column: x => x.DebtId,
                        principalTable: "Debts",
                        principalColumn: "DebtId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DailyOperations",
                columns: new[] { "DailyOperationId", "Amount", "ApplicationUserId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "Name", "Operation", "UserId" },
                values: new object[,]
                {
                    { new Guid("6ef244de-a44f-4f08-91fb-7c0445ea7807"), -300.5m, null, "SeedingData", new DateTime(2022, 5, 24, 10, 55, 9, 908, DateTimeKind.Local).AddTicks(5718), null, null, "Dinner", 2, new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b") },
                    { new Guid("6ef244de-a44f-4f08-91fb-7c0445ea7801"), 400m, null, "SeedingData", new DateTime(2022, 5, 24, 10, 55, 9, 908, DateTimeKind.Local).AddTicks(5870), null, null, "From salary", 1, new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b") }
                });

            migrationBuilder.InsertData(
                table: "Frequencies",
                columns: new[] { "FrequencyId", "ApplicationUserId", "Number", "Unit", "UserId" },
                values: new object[] { new Guid("2ef244de-a44f-4f08-91fb-7c0445ea7804"), null, 1, 2, new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b") });

            migrationBuilder.InsertData(
                table: "Goals",
                columns: new[] { "GoalId", "Amount", "ApplicationUserId", "CreatedBy", "CreatedDate", "Deadline", "Description", "LastModifiedBy", "LastModifiedDate", "Title", "UserId" },
                values: new object[] { new Guid("3ef244de-a44f-4f08-91fb-7c0445ea7802"), 511005m, null, "SeedingData", new DateTime(2022, 5, 24, 10, 55, 9, 908, DateTimeKind.Local).AddTicks(8092), new DateTime(2047, 5, 24, 10, 55, 9, 908, DateTimeKind.Local).AddTicks(7820), "Evry goal is possible to achieve, the question is how to do thisand what can I sacrifice to get on top (For sure not your health and other people!In our world we have endless possibilities, try one)?", null, null, "Debt repayment", new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b") });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "NoteId", "ApplicationUserId", "Content", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "TypeOfNote", "UserId" },
                values: new object[] { new Guid("5ef244de-a44f-4f08-91fb-7c0445ea7804"), null, "I devote myself to achieving the main goal and appreciate this path every day, find joy in every progress' step", "SeedingData", new DateTime(2022, 5, 24, 10, 55, 9, 909, DateTimeKind.Local).AddTicks(1908), null, null, 3, new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b") });

            migrationBuilder.InsertData(
                table: "Savings",
                columns: new[] { "SavingId", "ApplicationUserId", "CreatedBy", "CreatedDate", "LastModifiedBy", "LastModifiedDate", "TotalSaving", "UserId" },
                values: new object[] { new Guid("7ef244de-a44f-4f08-91fb-7c0445ea7802"), null, "SeedingData", new DateTime(2022, 5, 24, 10, 55, 9, 909, DateTimeKind.Local).AddTicks(3940), null, null, 0m, new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b") });

            migrationBuilder.InsertData(
                table: "Debts",
                columns: new[] { "DebtId", "ApplicationUserId", "CreatedBy", "CreatedDate", "FirstInstalment", "FlatInstalment", "FrequencyId", "Instalment", "InterestRate", "LastInstalment", "LastModifiedBy", "LastModifiedDate", "LoanAmount", "Name", "Total", "UserId" },
                values: new object[] { new Guid("1ef244de-a44f-4f08-91fb-7c0445ea7802"), null, "SeedingData", new DateTime(2022, 5, 24, 10, 55, 9, 908, DateTimeKind.Local).AddTicks(551), new DateTime(2022, 5, 24, 10, 55, 9, 906, DateTimeKind.Local).AddTicks(757), true, new Guid("2ef244de-a44f-4f08-91fb-7c0445ea7804"), 1703.35m, 4.7000000000000002, new DateTime(2047, 5, 24, 10, 55, 9, 907, DateTimeKind.Local).AddTicks(9810), null, null, 300000m, "Mortgage", 511005m, new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b") });

            migrationBuilder.InsertData(
                table: "Incomes",
                columns: new[] { "IncomeId", "Amount", "ApplicationUserId", "CreatedBy", "CreatedDate", "FirstRemit", "FrequencyId", "LastModifiedBy", "LastModifiedDate", "LastRemit", "Name", "UserId" },
                values: new object[] { new Guid("42787623-4c52-43fe-b0c9-b7044fb5929b"), 8000m, null, "SeedingData", new DateTime(2022, 5, 24, 10, 55, 9, 909, DateTimeKind.Local).AddTicks(286), new DateTime(2022, 5, 24, 10, 55, 9, 909, DateTimeKind.Local).AddTicks(146), new Guid("2ef244de-a44f-4f08-91fb-7c0445ea7804"), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salary", new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b") });

            migrationBuilder.InsertData(
                table: "Outcomes",
                columns: new[] { "OutcomeId", "Amount", "ApplicationUserId", "CreatedBy", "CreatedDate", "FirstRemit", "FrequencyId", "LastModifiedBy", "LastModifiedDate", "LastRemit", "Name", "UserId" },
                values: new object[] { new Guid("6ef244de-a44f-4f08-91fb-7c0445ea7804"), 600m, null, "SeedingData", new DateTime(2022, 5, 24, 10, 55, 9, 909, DateTimeKind.Local).AddTicks(3258), new DateTime(2022, 5, 24, 10, 55, 9, 909, DateTimeKind.Local).AddTicks(3249), new Guid("2ef244de-a44f-4f08-91fb-7c0445ea7804"), null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Utility bills", new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b") });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ContactId", "Address", "ApplicationUserId", "CreatedBy", "CreatedDate", "DebtId", "Email", "LastModifiedBy", "LastModifiedDate", "Name", "PhoneNumber", "UserId" },
                values: new object[] { new Guid("6ef244de-a44f-4f08-91fb-7c0445ea7807"), "ul. Grochowa 24, 65-901 Warszawa", null, "SeedingData", new DateTime(2022, 5, 24, 10, 55, 9, 908, DateTimeKind.Local).AddTicks(3237), new Guid("1ef244de-a44f-4f08-91fb-7c0445ea7802"), "mkapusta@gmail.com", null, null, "Repossession Man", "48789453784", new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b") });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ApplicationUserId",
                table: "Contacts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_DebtId",
                table: "Contacts",
                column: "DebtId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyOperations_ApplicationUserId",
                table: "DailyOperations",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Debts_ApplicationUserId",
                table: "Debts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Debts_FrequencyId",
                table: "Debts",
                column: "FrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Frequencies_ApplicationUserId",
                table: "Frequencies",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_ApplicationUserId",
                table: "Goals",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_ApplicationUserId",
                table: "Incomes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Incomes_FrequencyId",
                table: "Incomes",
                column: "FrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ApplicationUserId",
                table: "Notes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Outcomes_ApplicationUserId",
                table: "Outcomes",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Outcomes_FrequencyId",
                table: "Outcomes",
                column: "FrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Savings_ApplicationUserId",
                table: "Savings",
                column: "ApplicationUserId");
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
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "DailyOperations");

            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "Incomes");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Outcomes");

            migrationBuilder.DropTable(
                name: "Savings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Debts");

            migrationBuilder.DropTable(
                name: "Frequencies");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
